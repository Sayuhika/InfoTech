#include "stdafx.h"
#include "MHJ.h"


vector<double> Convolution(vector<double> &signal, vector<double> &impsig) 
{
	vector<double>result;

	for (int i = 0; i < signal.size(); i++)
	{
		double res = 0;
		
		// Циклическая свертка
		/*for (int k = 0; k < impsig.size(); k++)
		{
			res += signal[(i - k) % signal.size()] * impsig[k];
		}*/

		// Свертка с размножением импульсной характеристики
		for (int k = 0; k < signal.size(); k++)
		{
			res += signal[k] * impsig[(impsig.size() + i - k) % impsig.size()];
		}

		result.push_back(res);
	}

	return result;
}

double function(vector<double> &signal, vector<double> &impsig, vector<double> &convolution)
{
	double Functional = 0.0;

	vector<double> RecoveryData = MHJ::recsignal(signal, impsig);
	RecoveryData = Convolution(RecoveryData, impsig);

	for (int i = 0; i < convolution.size(); i++)
	{
		Functional += (RecoveryData[i] - convolution[i]) * (RecoveryData[i] - convolution[i]);
	}

	return Functional;
	// Реализует оптимизируемую функцию
	// Возвращает значение функции
	// количество параметров является членом класса, в противном случае изменить сигнатуру функции
	//	........
}

void MHJ::init() {
	j = 0;
	kk = signal.size();

	b.resize(kk);
	y.resize(kk);
	p.resize(kk);

	h = 10.;
	signal.clear();
	signal.push_back(1.);
	for (int i = 1; i < kk; i++) {
		signal.push_back((double)rand() / RAND_MAX);
	} // Задается начальное приближение

	k = h;
	for (int i = 0; i < kk; i++) {
		y[i] = p[i] = b[i] = signal[i];
	}
	fi = function(signal, impsig, convolution);
	ps = 0;   bs = 1;  fb = fi;
}

bool MHJ::iterate(double *pfv, double *TAU){
	signal[j] = y[j] + k;
	*pfv = z = function(signal, impsig, convolution);
	if (z >= fi) {
		signal[j] = y[j] - k;
		*pfv = z = function(signal, impsig, convolution);
		if (z < fi) {
			y[j] = signal[j];
		}
		else {
			signal[j] = y[j];
		}
	}
	else {
		y[j] = signal[j];
	}
	*pfv = fi = function(signal, impsig, convolution);

	if (j < kk - 1) { j++;  return true; }
	if (fi + *TAU >= fb) {
		if (ps == 1 && bs == 0) {
			for (int i = 0; i < kk; i++) {
				p[i] = y[i] = signal[i] = b[i];
			}
			*pfv = z = function(signal, impsig, convolution);
			bs = 1;   ps = 0;   fi = z;   fb = z;   j = 0;
			return true;
		}
		k /= 10.;
		if (k < *TAU) return false;
		j = 0;
		return true;
	}

	for (int i = 0; i < kk; i++) {
		p[i] = 2 * y[i] - b[i];
		b[i] = y[i];
		signal[i] = p[i];

		y[i] = signal[i];
	}
	*pfv = z = function(signal, impsig, convolution);
	fb = fi;   ps = 1;   bs = 0;   fi = z;   j = 0;
	return true;
}

vector<double> MHJ::recsignal(vector<double> &signal, vector<double> &impsig)
{
	vector<double> result;

	for (int i = 0; i < signal.size(); i++)
	{
		double Pow = -1.0;

		for (int k = 0; k < signal.size(); k++)
		{
			Pow -= signal[k] * impsig[(k - i + impsig.size()) % impsig.size()];
		}

		result.push_back(exp(Pow));
	}

	return result;
}
