#pragma once
#include <vector>

using namespace std;

vector<double> Convolution(vector<double> &signal, vector<double> &impsig);

class MHJ {
public:
	vector<double> signal, impsig, convolution, b, y, p;
	int j, bs, ps, kk;
	double z, h, k, fi, fb;
	void init();
	bool iterate(double *pfv, double *TAU);
	static vector<double> recsignal(vector<double> &signal, vector<double> &impsig);
};