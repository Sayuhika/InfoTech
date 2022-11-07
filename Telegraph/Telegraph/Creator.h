#pragma once

vector<double> CreateSignal(double amplitude_value, double omega_value, double frequency_value, double frequency_of_d_value, double phase, double T_value, double dooms, vector<int>* T)
{
	vector<double> result_data;

	double n_phase = phase;

	for (int i = 0; i < T_value; i++)
	{
		if (T->at(i) == 0)
		{
			for (int j = 0; j < dooms; j++)
			{
				n_phase += (frequency_value - omega_value);
				result_data.push_back(amplitude_value*cos(2*M_PI*(n_phase)/frequency_of_d_value));
			}
		}
		else
		{
			for (int j = 0; j < dooms; j++)
			{
				n_phase += (frequency_value + omega_value);
				result_data.push_back(amplitude_value*cos(2 * M_PI*(n_phase)/frequency_of_d_value));
			}
		}
	}
	
	return result_data;
}