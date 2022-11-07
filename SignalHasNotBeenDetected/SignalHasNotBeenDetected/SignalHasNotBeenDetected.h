
// SignalHasNotBeenDetected.h: главный файл заголовка для приложения PROJECT_NAME
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

// CSignalHasNotBeenDetectedApp:
// Сведения о реализации этого класса: SignalHasNotBeenDetected.cpp
//

class CSignalHasNotBeenDetectedApp : public CWinApp
{
public:
	CSignalHasNotBeenDetectedApp();

// Переопределение
public:
	virtual BOOL InitInstance();
	double FindMaxValue(vector<double>* A);
// Реализация

	DECLARE_MESSAGE_MAP()
};

extern CSignalHasNotBeenDetectedApp theApp;
