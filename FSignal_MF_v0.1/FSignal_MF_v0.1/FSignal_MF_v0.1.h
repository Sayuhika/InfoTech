
// FSignal_MF_v0.1.h: главный файл заголовка для приложения PROJECT_NAME
//

#pragma once

#ifndef __AFXWIN_H__
	#error "включить stdafx.h до включения этого файла в PCH"
#endif

#include "resource.h"		// основные символы


// CFSignalMFv01App:
// Сведения о реализации этого класса: FSignal_MF_v0.1.cpp
//

class CFSignalMFv01App : public CWinApp
{
public:
	CFSignalMFv01App();

// Переопределение
public:
	virtual BOOL InitInstance();

// Реализация

	DECLARE_MESSAGE_MAP()
};

extern CFSignalMFv01App theApp;
