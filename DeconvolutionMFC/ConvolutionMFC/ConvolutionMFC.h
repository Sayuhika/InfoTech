
// ConvolutionMFC.h : главный файл заголовка для приложения PROJECT_NAME
//

#pragma once

#ifndef __AFXWIN_H__
	#error "включить stdafx.h до включения этого файла в PCH"
#endif

#include "resource.h"		// основные символы

#define _USE_MATH_DEFINES

#include <math.h>
#include <vector>

using namespace std;

// CConvolutionMFCApp:
// О реализации данного класса см. ConvolutionMFC.cpp	
//

class CConvolutionMFCApp : public CWinApp
{
public:
	CConvolutionMFCApp();

// Переопределение
public:
	virtual BOOL InitInstance();
	double FindMaxValue(vector<double>* A);
	bool stopDeconvolutionFlag = true;
	double functionalValue;
	double TAU;
// Реализация

	DECLARE_MESSAGE_MAP()
};

extern CConvolutionMFCApp theApp;