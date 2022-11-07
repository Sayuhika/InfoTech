#pragma once

vector<double> CreateSignal(double vf1, double vf2, double vf3, int D, int B1, int B2, double phase)
{
	vector<double> result_data;

	for (int i = 0; i <= B1; i++)
	{
		result_data.push_back(sin(2 * M_PI*vf1*i + phase));
	}

	phase += 2 * M_PI*vf1*(B1);

	for (int i = B1 + 1; i <= B2; i++)
	{
		result_data.push_back(sin(2 * M_PI*vf2*(i - B1) + phase));
	}

	phase += 2 * M_PI*vf2*(B2 - B1);

	for (int i = B2 + 1; i < D; i++)
	{
		result_data.push_back(sin(2 * M_PI*vf3*(i - B2) + phase));
	}

	return result_data;
}

vector<double> DoSomeNoiseWithSignal(vector<double>* signal, double Noise_Energy_Percentage)
{
	vector<double> Rand_Noise, Noisy_Signal_A_data;
	double Signal_Energy(0), Noise_Energy(0);

	for (int i = 0; i < signal->size(); i++)
	{
		// Генерация шума
		double sum = 0;
		for (int j = 0; j < 12; j++) { sum += rand(); };
		Rand_Noise.push_back(sum / (12 * RAND_MAX) - 0.5);

		// Расчет энергии сигнала и шума
		Signal_Energy += signal->at(i) * signal->at(i);
		Noise_Energy += Rand_Noise.back() * Rand_Noise.back();
	}

	// Расчет коэффициента 
	double k = sqrt(Signal_Energy * Noise_Energy_Percentage / (100 * Noise_Energy));

	// Расчет зашумленного сигнала
	for (int i = 0; i < signal->size(); i++)
	{
		Noisy_Signal_A_data.push_back(signal->at(i) + Rand_Noise[i] * k);
	}

	return Noisy_Signal_A_data;
}