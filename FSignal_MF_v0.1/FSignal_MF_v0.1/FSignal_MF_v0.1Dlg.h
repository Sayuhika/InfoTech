
// FSignal_MF_v0.1Dlg.h: файл заголовка
//

#pragma once
#include <vector>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <complex>
#include "Drawer.h"



// Диалоговое окно CFSignalMFv01Dlg
class CFSignalMFv01Dlg : public CDialogEx
{
// Создание
public:
	CFSignalMFv01Dlg(CWnd* pParent = nullptr);	// стандартный конструктор

// Данные диалогового окна
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_FSIGNAL_MF_V01_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// поддержка DDX/DDV


// Реализация
protected:
	HICON m_hIcon;

	// Созданные функции схемы сообщений
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	double Amplitude_1;
	double Amplitude_2;
	double Amplitude_3;
	double Frequency_1;
	double Frequency_2;
	double Frequency_3;
	afx_msg void OnEnChangeEdit6();
	double Noise_Energy_Percentage;
	double Residual_Signal_Energy_Percentage;
	double Signal_Duration;

	Drawer Drawer_Purified_and_Normal_Graphs;
	Drawer Drawer_Noisy_Graph;
	Drawer Drawer_Spectra;
	afx_msg void OnBnClickedButton1();
	double Phase_1;
	double Phase_2;
	double Phase_3;
	double residual_value;
};
