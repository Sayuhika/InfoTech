#pragma once
#include <complex>

using namespace std;

class QESolver 
{
private:
	double a, b, c, D;
	bool SolveD();
public:
	QESolver();
	QESolver(double _a, double _b, double _c);
	bool SetParams(double _a, double _b, double _c);
	bool GetSolve(complex<double>& x1, complex<double>& x2);
	~QESolver();
};