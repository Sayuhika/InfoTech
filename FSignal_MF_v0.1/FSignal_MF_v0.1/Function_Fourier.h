// *.h file
#pragma once

void FFourier(vector<complex<double>> &data, int n, int is)
{
	int i, j, istep;
	int m, mmax;
	float r, r1, theta, w_r, w_i, temp_r, temp_i;
	float pi = 3.1415926f;

	r = pi * is;
	j = 0;
	for (i = 0; i < n; i++)
	{
		if (i < j)
		{
			temp_r = data[j].real();
			temp_i = data[j].imag();
			data[j] = data[i];
			data[i] = complex<double>(temp_r, temp_i);
		}
		m = n >> 1;
		while (j >= m) { j -= m; m = (m + 1) / 2; }
		j += m;
	}
	mmax = 1;
	while (mmax < n)
	{
		istep = mmax << 1;
		r1 = r / (float)mmax;
		for (m = 0; m < mmax; m++)
		{
			theta = r1 * m;
			w_r = (float)cos((double)theta);
			w_i = (float)sin((double)theta);
			for (i = m; i < n; i += istep)
			{
				j = i + mmax;
				temp_r = w_r * data[j].real() - w_i * data[j].imag();
				temp_i = w_r * data[j].imag() + w_i * data[j].real();
				data[j] = complex<double>(data[i].real() - temp_r, data[i].imag() - temp_i);
				data[i] += complex<double>(temp_r, temp_i);
			}
		}
		mmax = istep;
	}
	if (is > 0)
		for (i = 0; i < n; i++)
		{
			data[i] /= (float)n;
		}

}
