using System;

namespace NAudio.Dsp
{
	internal class WdlResampler
	{
		private class WDL_Resampler_IIRFilter
		{
			private double m_fpos;

			private double m_a1;

			private double m_a2;

			private double m_b0;

			private double m_b1;

			private double m_b2;

			private double[,] m_hist;

			public WDL_Resampler_IIRFilter()
			{
				m_fpos = -1.0;
				Reset();
			}

			public void Reset()
			{
				m_hist = new double[256, 4];
			}

			public void setParms(double fpos, double Q)
			{
				if (!(Math.Abs(fpos - m_fpos) < 1E-06))
				{
					m_fpos = fpos;
					double num = fpos * Math.PI;
					double num2 = Math.Cos(num);
					double num3 = Math.Sin(num) / (2.0 * Q);
					double num4 = 1.0 / (1.0 + num3);
					m_b1 = (1.0 - num2) * num4;
					m_b2 = (m_b0 = m_b1 * 0.5);
					m_a1 = -2.0 * num2 * num4;
					m_a2 = (1.0 - num3) * num4;
				}
			}

			public void Apply(float[] inBuffer, int inIndex, float[] outBuffer, int outIndex, int ns, int span, int w)
			{
				double b = m_b0;
				double b2 = m_b1;
				double b3 = m_b2;
				double a = m_a1;
				double a2 = m_a2;
				while (ns-- != 0)
				{
					double num2 = inBuffer[inIndex];
					inIndex += span;
					double x = num2 * b + m_hist[w, 0] * b2 + m_hist[w, 1] * b3 - m_hist[w, 2] * a - m_hist[w, 3] * a2;
					m_hist[w, 1] = m_hist[w, 0];
					m_hist[w, 0] = num2;
					m_hist[w, 3] = m_hist[w, 2];
					m_hist[w, 2] = denormal_filter(x);
					outBuffer[outIndex] = (float)m_hist[w, 2];
					outIndex += span;
				}
			}

			private double denormal_filter(float x)
			{
				return x;
			}

			private double denormal_filter(double x)
			{
				return x;
			}
		}

		private const int WDL_RESAMPLE_MAX_FILTERS = 4;

		private const int WDL_RESAMPLE_MAX_NCH = 64;

		private const double PI = Math.PI;

		private double m_sratein;

		private double m_srateout;

		private double m_fracpos;

		private double m_ratio;

		private double m_filter_ratio;

		private float m_filterq;

		private float m_filterpos;

		private float[] m_rsinbuf;

		private float[] m_filter_coeffs;

		private WDL_Resampler_IIRFilter m_iirfilter;

		private int m_filter_coeffs_size;

		private int m_last_requested;

		private int m_filtlatency;

		private int m_samples_in_rsinbuf;

		private int m_lp_oversize;

		private int m_sincsize;

		private int m_filtercnt;

		private int m_sincoversize;

		private bool m_interp;

		private bool m_feedmode;

		public WdlResampler()
		{
			m_filterq = 0.707f;
			m_filterpos = 0.693f;
			m_sincoversize = 0;
			m_lp_oversize = 1;
			m_sincsize = 0;
			m_filtercnt = 1;
			m_interp = true;
			m_feedmode = false;
			m_filter_coeffs_size = 0;
			m_sratein = 44100.0;
			m_srateout = 44100.0;
			m_ratio = 1.0;
			m_filter_ratio = -1.0;
			Reset();
		}

		public void SetMode(bool interp, int filtercnt, bool sinc, int sinc_size = 64, int sinc_interpsize = 32)
		{
			m_sincsize = ((sinc && sinc_size >= 4) ? ((sinc_size > 8192) ? 8192 : sinc_size) : 0);
			m_sincoversize = ((m_sincsize == 0) ? 1 : ((sinc_interpsize <= 1) ? 1 : ((sinc_interpsize >= 4096) ? 4096 : sinc_interpsize)));
			m_filtercnt = ((m_sincsize == 0) ? ((filtercnt > 0) ? ((filtercnt >= 4) ? 4 : filtercnt) : 0) : 0);
			m_interp = (interp && m_sincsize == 0);
			if (m_sincsize == 0)
			{
				m_filter_coeffs = new float[0];
				m_filter_coeffs_size = 0;
			}
			if (m_filtercnt == 0)
			{
				m_iirfilter = null;
			}
		}

		public void SetFilterParms(float filterpos = 0.693f, float filterq = 0.707f)
		{
			m_filterpos = filterpos;
			m_filterq = filterq;
		}

		public void SetFeedMode(bool wantInputDriven)
		{
			m_feedmode = wantInputDriven;
		}

		public void Reset(double fracpos = 0.0)
		{
			m_last_requested = 0;
			m_filtlatency = 0;
			m_fracpos = fracpos;
			m_samples_in_rsinbuf = 0;
			if (m_iirfilter != null)
			{
				m_iirfilter.Reset();
			}
		}

		public void SetRates(double rate_in, double rate_out)
		{
			if (rate_in < 1.0)
			{
				rate_in = 1.0;
			}
			if (rate_out < 1.0)
			{
				rate_out = 1.0;
			}
			if (rate_in != m_sratein || rate_out != m_srateout)
			{
				m_sratein = rate_in;
				m_srateout = rate_out;
				m_ratio = m_sratein / m_srateout;
			}
		}

		public double GetCurrentLatency()
		{
			double num = ((double)m_samples_in_rsinbuf - (double)m_filtlatency) / m_sratein;
			if (num < 0.0)
			{
				num = 0.0;
			}
			return num;
		}

		public int ResamplePrepare(int out_samples, int nch, out float[] inbuffer, out int inbufferOffset)
		{
			if (nch > 64 || nch < 1)
			{
				inbuffer = null;
				inbufferOffset = 0;
				return 0;
			}
			int num = 0;
			if (m_sincsize > 1)
			{
				num = m_sincsize;
			}
			int num2 = num / 2;
			if (num2 > 1 && m_samples_in_rsinbuf < num2 - 1)
			{
				m_filtlatency += num2 - 1 - m_samples_in_rsinbuf;
				m_samples_in_rsinbuf = num2 - 1;
				if (m_samples_in_rsinbuf > 0)
				{
					m_rsinbuf = new float[m_samples_in_rsinbuf * nch];
				}
			}
			int num3 = 0;
			num3 = (m_feedmode ? out_samples : ((int)(m_ratio * (double)out_samples) + 4 + num - m_samples_in_rsinbuf));
			if (num3 < 0)
			{
				num3 = 0;
			}
			while (true)
			{
				Array.Resize(ref m_rsinbuf, (m_samples_in_rsinbuf + num3) * nch);
				int num4 = m_rsinbuf.Length / ((nch == 0) ? 1 : nch) - m_samples_in_rsinbuf;
				if (num4 == num3)
				{
					break;
				}
				if (num3 > 4 && num4 == 0)
				{
					num3 /= 2;
					continue;
				}
				num3 = num4;
				break;
			}
			inbuffer = m_rsinbuf;
			inbufferOffset = m_samples_in_rsinbuf * nch;
			m_last_requested = num3;
			return num3;
		}

		public int ResampleOut(float[] outBuffer, int outBufferIndex, int nsamples_in, int nsamples_out, int nch)
		{
			if (nch > 64 || nch < 1)
			{
				return 0;
			}
			if (m_filtercnt > 0 && m_ratio > 1.0 && nsamples_in > 0)
			{
				if (m_iirfilter == null)
				{
					m_iirfilter = new WDL_Resampler_IIRFilter();
				}
				int filtercnt = m_filtercnt;
				m_iirfilter.setParms(1.0 / m_ratio * (double)m_filterpos, m_filterq);
				int num = m_samples_in_rsinbuf * nch;
				int num2 = 0;
				for (int i = 0; i < nch; i++)
				{
					for (int j = 0; j < filtercnt; j++)
					{
						m_iirfilter.Apply(m_rsinbuf, num + i, m_rsinbuf, num + i, nsamples_in, nch, num2++);
					}
				}
			}
			m_samples_in_rsinbuf += Math.Min(nsamples_in, m_last_requested);
			int num4 = m_samples_in_rsinbuf;
			if (nsamples_in < m_last_requested)
			{
				int num5 = (m_last_requested - nsamples_in) * 2 + m_sincsize * 2;
				int num6 = (m_samples_in_rsinbuf + num5) * nch;
				Array.Resize(ref m_rsinbuf, num6);
				if (m_rsinbuf.Length == num6)
				{
					Array.Clear(m_rsinbuf, m_samples_in_rsinbuf * nch, num5 * nch);
					num4 = m_samples_in_rsinbuf + num5;
				}
			}
			int num7 = 0;
			double num8 = m_fracpos;
			double ratio = m_ratio;
			int num9 = 0;
			int num10 = outBufferIndex;
			int num11 = nsamples_out;
			int num12 = 0;
			if (m_sincsize != 0)
			{
				if (m_ratio > 1.0)
				{
					BuildLowPass(1.0 / (m_ratio * 1.03));
				}
				else
				{
					BuildLowPass(1.0);
				}
				int filter_coeffs_size = m_filter_coeffs_size;
				int num13 = num4 - filter_coeffs_size;
				num12 = filter_coeffs_size / 2 - 1;
				int filterIndex = 0;
				if (nch == 1)
				{
					while (num11-- != 0)
					{
						int num15 = (int)num8;
						if (num15 >= num13 - 1)
						{
							break;
						}
						SincSample1(outBuffer, num10, m_rsinbuf, num9 + num15, num8 - (double)num15, m_filter_coeffs, filterIndex, filter_coeffs_size);
						num10++;
						num8 += ratio;
						num7++;
					}
				}
				else if (nch == 2)
				{
					while (num11-- != 0)
					{
						int num17 = (int)num8;
						if (num17 >= num13 - 1)
						{
							break;
						}
						SincSample2(outBuffer, num10, m_rsinbuf, num9 + num17 * 2, num8 - (double)num17, m_filter_coeffs, filterIndex, filter_coeffs_size);
						num10 += 2;
						num8 += ratio;
						num7++;
					}
				}
				else
				{
					while (num11-- != 0)
					{
						int num19 = (int)num8;
						if (num19 >= num13 - 1)
						{
							break;
						}
						SincSample(outBuffer, num10, m_rsinbuf, num9 + num19 * nch, num8 - (double)num19, nch, m_filter_coeffs, filterIndex, filter_coeffs_size);
						num10 += nch;
						num8 += ratio;
						num7++;
					}
				}
			}
			else if (!m_interp)
			{
				if (nch == 1)
				{
					while (num11-- != 0)
					{
						int num21 = (int)num8;
						if (num21 >= num4)
						{
							break;
						}
						outBuffer[num10++] = m_rsinbuf[num9 + num21];
						num8 += ratio;
						num7++;
					}
				}
				else if (nch == 2)
				{
					while (num11-- != 0)
					{
						int num24 = (int)num8;
						if (num24 >= num4)
						{
							break;
						}
						num24 += num24;
						outBuffer[num10] = m_rsinbuf[num9 + num24];
						outBuffer[num10 + 1] = m_rsinbuf[num9 + num24 + 1];
						num10 += 2;
						num8 += ratio;
						num7++;
					}
				}
				else
				{
					while (num11-- != 0)
					{
						int num26 = (int)num8;
						if (num26 >= num4)
						{
							break;
						}
						Array.Copy(m_rsinbuf, num9 + num26 * nch, outBuffer, num10, nch);
						num10 += nch;
						num8 += ratio;
						num7++;
					}
				}
			}
			else if (nch == 1)
			{
				while (num11-- != 0)
				{
					int num28 = (int)num8;
					double num29 = num8 - (double)num28;
					if (num28 >= num4 - 1)
					{
						break;
					}
					double num30 = 1.0 - num29;
					int num31 = num9 + num28;
					outBuffer[num10++] = (float)((double)m_rsinbuf[num31] * num30 + (double)m_rsinbuf[num31 + 1] * num29);
					num8 += ratio;
					num7++;
				}
			}
			else if (nch == 2)
			{
				while (num11-- != 0)
				{
					int num34 = (int)num8;
					double num35 = num8 - (double)num34;
					if (num34 >= num4 - 1)
					{
						break;
					}
					double num36 = 1.0 - num35;
					int num37 = num9 + num34 * 2;
					outBuffer[num10] = (float)((double)m_rsinbuf[num37] * num36 + (double)m_rsinbuf[num37 + 2] * num35);
					outBuffer[num10 + 1] = (float)((double)m_rsinbuf[num37 + 1] * num36 + (double)m_rsinbuf[num37 + 3] * num35);
					num10 += 2;
					num8 += ratio;
					num7++;
				}
			}
			else
			{
				while (num11-- != 0)
				{
					int num39 = (int)num8;
					double num40 = num8 - (double)num39;
					if (num39 >= num4 - 1)
					{
						break;
					}
					double num41 = 1.0 - num40;
					int num42 = nch;
					int num43 = num9 + num39 * nch;
					while (num42-- != 0)
					{
						outBuffer[num10++] = (float)((double)m_rsinbuf[num43] * num41 + (double)m_rsinbuf[num43 + nch] * num40);
						num43++;
					}
					num8 += ratio;
					num7++;
				}
			}
			if (m_filtercnt > 0 && m_ratio < 1.0 && num7 > 0)
			{
				if (m_iirfilter == null)
				{
					m_iirfilter = new WDL_Resampler_IIRFilter();
				}
				int filtercnt2 = m_filtercnt;
				m_iirfilter.setParms(m_ratio * (double)m_filterpos, m_filterq);
				int num46 = 0;
				for (int k = 0; k < nch; k++)
				{
					for (int l = 0; l < filtercnt2; l++)
					{
						m_iirfilter.Apply(outBuffer, k, outBuffer, k, num7, nch, num46++);
					}
				}
			}
			if (num7 > 0 && num4 > m_samples_in_rsinbuf)
			{
				double num48 = (num8 - (double)m_samples_in_rsinbuf + (double)num12) / ratio;
				if (num48 > 0.0)
				{
					num7 -= (int)(num48 + 0.5);
					if (num7 < 0)
					{
						num7 = 0;
					}
				}
			}
			int num49 = (int)num8;
			m_fracpos = num8 - (double)num49;
			m_samples_in_rsinbuf -= num49;
			if (m_samples_in_rsinbuf <= 0)
			{
				m_samples_in_rsinbuf = 0;
			}
			else
			{
				Array.Copy(m_rsinbuf, num9 + num49 * nch, m_rsinbuf, num9, m_samples_in_rsinbuf * nch);
			}
			return num7;
		}

		private void BuildLowPass(double filtpos)
		{
			int sincsize = m_sincsize;
			int sincoversize = m_sincoversize;
			if (m_filter_ratio == filtpos && m_filter_coeffs_size == sincsize && m_lp_oversize == sincoversize)
			{
				return;
			}
			m_lp_oversize = sincoversize;
			m_filter_ratio = filtpos;
			int num = (sincsize + 1) * m_lp_oversize;
			Array.Resize(ref m_filter_coeffs, num);
			if (m_filter_coeffs.Length == num)
			{
				m_filter_coeffs_size = sincsize;
				int num2 = sincsize * m_lp_oversize;
				int num3 = num2 / 2;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = Math.PI * 2.0 / (double)num2;
				double num7 = Math.PI / (double)m_lp_oversize * filtpos;
				double num8 = num7 * (double)(-num3);
				for (int i = -num3; i < num3 + m_lp_oversize; i++)
				{
					double num9 = 287.0 / 800.0 - 0.48829 * Math.Cos(num5) + 0.14128 * Math.Cos(2.0 * num5) - 0.01168 * Math.Cos(6.0 * num5);
					if (i != 0)
					{
						num9 *= Math.Sin(num8) / num8;
					}
					num5 += num6;
					num8 += num7;
					m_filter_coeffs[num3 + i] = (float)num9;
					if (i < num3)
					{
						num4 += num9;
					}
				}
				num4 = (double)m_lp_oversize / num4;
				for (int i = 0; i < num2 + m_lp_oversize; i++)
				{
					m_filter_coeffs[i] = (float)((double)m_filter_coeffs[i] * num4);
				}
			}
			else
			{
				m_filter_coeffs_size = 0;
			}
		}

		private void SincSample(float[] outBuffer, int outBufferIndex, float[] inBuffer, int inBufferIndex, double fracpos, int nch, float[] filter, int filterIndex, int filtsz)
		{
			int lp_oversize = m_lp_oversize;
			fracpos *= (double)lp_oversize;
			int num = (int)fracpos;
			filterIndex += lp_oversize - 1 - num;
			fracpos -= (double)num;
			for (int i = 0; i < nch; i++)
			{
				double num2 = 0.0;
				double num3 = 0.0;
				int num4 = filterIndex;
				int num5 = inBufferIndex + i;
				int num6 = filtsz;
				while (num6-- != 0)
				{
					num2 += (double)(filter[num4] * inBuffer[num5]);
					num3 += (double)(filter[num4 + 1] * inBuffer[num5]);
					num5 += nch;
					num4 += lp_oversize;
				}
				outBuffer[outBufferIndex + i] = (float)(num2 * fracpos + num3 * (1.0 - fracpos));
			}
		}

		private void SincSample1(float[] outBuffer, int outBufferIndex, float[] inBuffer, int inBufferIndex, double fracpos, float[] filter, int filterIndex, int filtsz)
		{
			int lp_oversize = m_lp_oversize;
			fracpos *= (double)lp_oversize;
			int num = (int)fracpos;
			filterIndex += lp_oversize - 1 - num;
			fracpos -= (double)num;
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = filterIndex;
			int num5 = inBufferIndex;
			int num6 = filtsz;
			while (num6-- != 0)
			{
				num2 += (double)(filter[num4] * inBuffer[num5]);
				num3 += (double)(filter[num4 + 1] * inBuffer[num5]);
				num5++;
				num4 += lp_oversize;
			}
			outBuffer[outBufferIndex] = (float)(num2 * fracpos + num3 * (1.0 - fracpos));
		}

		private void SincSample2(float[] outptr, int outBufferIndex, float[] inBuffer, int inBufferIndex, double fracpos, float[] filter, int filterIndex, int filtsz)
		{
			int lp_oversize = m_lp_oversize;
			fracpos *= (double)lp_oversize;
			int num = (int)fracpos;
			filterIndex += lp_oversize - 1 - num;
			fracpos -= (double)num;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			int num6 = filterIndex;
			int num7 = inBufferIndex;
			int num8 = filtsz / 2;
			while (num8-- != 0)
			{
				num2 += (double)(filter[num6] * inBuffer[num7]);
				num3 += (double)(filter[num6] * inBuffer[num7 + 1]);
				num4 += (double)(filter[num6 + 1] * inBuffer[num7]);
				num5 += (double)(filter[num6 + 1] * inBuffer[num7 + 1]);
				num2 += (double)(filter[num6 + lp_oversize] * inBuffer[num7 + 2]);
				num3 += (double)(filter[num6 + lp_oversize] * inBuffer[num7 + 3]);
				num4 += (double)(filter[num6 + lp_oversize + 1] * inBuffer[num7 + 2]);
				num5 += (double)(filter[num6 + lp_oversize + 1] * inBuffer[num7 + 3]);
				num7 += 4;
				num6 += lp_oversize * 2;
			}
			outptr[outBufferIndex] = (float)(num2 * fracpos + num4 * (1.0 - fracpos));
			outptr[outBufferIndex + 1] = (float)(num3 * fracpos + num5 * (1.0 - fracpos));
		}
	}
}
