
// Telegraph.h: главный файл заголовка для приложения PROJECT_NAME
//

#pragma once

#ifndef __AFXWIN_H__
	#error "включить stdafx.h до включения этого файла в PCH"
#endif

#include "resource.h"		// основные символы

#define _USE_MATH_DEFINES

#include <math.h>
#include <complex>



// CTelegraphApp:
// Сведения о реализации этого класса: Telegraph.cpp
//

class CTelegraphApp : public CWinApp
{
public:
	CTelegraphApp();

// Переопределение
public:
	virtual BOOL InitInstance();
	double FindMaxValue(vector<double>* A);
// Реализация

	DECLARE_MESSAGE_MAP()
};

extern CTelegraphApp theApp;
