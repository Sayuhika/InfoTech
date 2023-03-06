#include "pch.h"
#include "QuadEqua.h"

//using namespace std;
//
//bool TrySetParameter(double& p)
//{
//	string s;
//	cin >> s;
//
//	try { 
//		p = stod(s);
//	}
//	catch (const exception&){
//		cout << "Parameter can be number only" << endl;
//		return false;
//	}
//
//	return true;
//}
//
//int main()
//{
//	double a, b, c;
//	cout << "a * x^2 + b * x + c = 0" << endl;
//	cout << endl << "Set parameters:" << endl;
//	cout << "a = ";
//	while (!TrySetParameter(a)) { cout << "a = "; };
//	cout << "b = "; 
//	while (!TrySetParameter(b)) { cout << "b = "; };
//	cout << "c = ";
//	while (!TrySetParameter(c)) { cout << "c = "; };
//
//	complex<double> x1, x2;
//	shared_ptr<QESolver> Solver = make_shared<QESolver>();
//	Solver->SetParams(a, b, c);
//	Solver->GetSolve(x1, x2);
//
//	// Result output
//	cout << endl << "Solve:" << endl;
//	cout << "x1: " << "real: (" << x1.real() << ") imag: (" << x1.imag() << ")" << endl;
//	cout << "x2: " << "real: (" << x2.real() << ") imag: (" << x2.imag() << ")" << endl;
//
//	return 0;
//}
