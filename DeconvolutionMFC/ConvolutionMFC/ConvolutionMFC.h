
// ConvolutionMFC.h : ������� ���� ��������� ��� ���������� PROJECT_NAME
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�������� stdafx.h �� ��������� ����� ����� � PCH"
#endif

#include "resource.h"		// �������� �������

#define _USE_MATH_DEFINES

#include <math.h>
#include <vector>

using namespace std;

// CConvolutionMFCApp:
// � ���������� ������� ������ ��. ConvolutionMFC.cpp	
//

class CConvolutionMFCApp : public CWinApp
{
public:
	CConvolutionMFCApp();

// ���������������
public:
	virtual BOOL InitInstance();
	double FindMaxValue(vector<double>* A);
	bool stopDeconvolutionFlag = true;
	double functionalValue;
	double TAU;
// ����������

	DECLARE_MESSAGE_MAP()
};

extern CConvolutionMFCApp theApp;