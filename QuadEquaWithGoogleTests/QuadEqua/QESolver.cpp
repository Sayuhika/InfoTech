#include "QESolver.h"
#include <cmath>

using namespace std;

QESolver::QESolver() 
{
	a = NAN;
	b = NAN;
	c = NAN;
};

QESolver::QESolver(double _a, double _b, double _c)
{
	try{
		a = _a;
		b = _b;
		c = _c;
	}
	catch (const exception&){ throw runtime_error("Failed to initialize class"); }
};

bool QESolver::SolveD()
{
	try{
		D = b * b - 4 * a * c;
	}
	catch (const exception&){ return false; }

	return true;
};

bool QESolver::SetParams(double _a, double _b, double _c)
{
	try{
		a = _a;
		b = _b;
		c = _c;
	}
	catch (const exception&){ return false; }

	return true;
};

bool QESolver::GetSolve(complex<double>& x1, complex<double>& x2)
{
	if (SolveD()){
		try{
			x1 = ((-b) + sqrt(complex<double>(D))) * 0.5 / (a);
			x2 = ((-b) - sqrt(complex<double>(D))) * 0.5 / (a);
		}
		catch (const exception&){ return false; }

		if (isnan(x1.real()) || isnan(x1.imag()) || isnan(x2.real()) || isnan(x2.imag())) {
			return false;
		}
	}
	else{ return false; }

	return true;
};

QESolver::~QESolver() {};
