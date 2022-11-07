
// ConvolutionMFCDlg.h : файл заголовка
//

#pragma once

#include "Drawer.h"
#include "MHJ.h"

// диалоговое окно CConvolutionMFCDlg
class CConvolutionMFCDlg : public CDialogEx
{
// Создание
public:
	CConvolutionMFCDlg(CWnd* pParent = NULL);	// стандартный конструктор

// Данные диалогового окна
	enum { IDD = IDD_CONVOLUTIONMFC_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// поддержка DDX/DDV


// Реализация
protected:
	HICON m_hIcon;

	// Созданные функции схемы сообщений
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	double GC_amplitude_1;
	double GC_amplitude_2;
	double GC_amplitude_3;
	double GC_meanv_1;
	double GC_meanv_2;
	double GC_meanv_3;
	double GC_deviation_1;
	double GC_deviation_2;
	double GC_deviation_3;
	double Imp_amplitude;
	double Imp_deviation;
	double Noise_power_percentage;
	double Precision;
	afx_msg void OnBnClickedButtonDrow();
	int Signal_length;
	int Impulse_length;
	Drawer drawerSignal;
	Drawer drawerImpRes;
	Drawer drawerConvolution;
	BOOL noiseMode;
	afx_msg void OnBnClickedButtonStart();
	double inputError;
	double outputError;
	vector<double> Signal_values, DeSignal_values, Impulse_values, Convolution_values, DeConvolution_values;
	MHJ *Processor;
	afx_msg void OnBnClickedButtonStop();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
};
