#pragma once

class AutoRegression
{
	public:
		AutoRegression()
		{

		};

		~AutoRegression()
		{

		};

		vector<double> Errors(vector<double>* Signal, double frequency);
		vector<double> FlatErrors(vector<double>* Errors, int n);
};