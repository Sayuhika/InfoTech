#include "stdafx.h"
#include "SignalHasNotBeenDetected.h"
#include "AutoRegression.h"


vector<double> AutoRegression::Errors (vector<double>* Signal, double frequency)
{
	double a1 = -2 * cos(frequency * 2 * M_PI);
	double a2 = 1;
	double sum;

	vector<double> res;

	res.push_back(0);
	res.push_back(0);

	for (int i = 2; i < Signal->size(); i++)
	{
		sum = Signal->at(i) + a1 * Signal->at(i - 1) + a2 * Signal->at(i - 2);
		res.push_back(sum*sum*10);
	}

	return (res);
}

vector<double> AutoRegression::FlatErrors(vector<double>* Errors, int L)
{
	vector<double> res;
	double h = 1 / L;

	for (int i = L / 2; i < Errors->size() - L / 2 ; i++)
	{
		double sum = 0;
		for (int j = - L / 2; j <= L / 2; j++)
		{
				sum += Errors->at(i - j);
		}
		res.push_back(sum/L);
	}

	
	for (int i = 0; i < L / 2; i++)
	{
		res.insert(res.begin(), res.front());
		res.push_back(res.back());
	}
	
	return (res);
}