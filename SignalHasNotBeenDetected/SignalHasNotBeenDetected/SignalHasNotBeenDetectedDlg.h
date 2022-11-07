
// SignalHasNotBeenDetectedDlg.h: файл заголовка
//

#pragma once

#include "Drawer.h"

// Диалоговое окно CSignalHasNotBeenDetectedDlg
class CSignalHasNotBeenDetectedDlg : public CDialogEx
{
// Создание
public:
	CSignalHasNotBeenDetectedDlg(CWnd* pParent = nullptr);	// стандартный конструктор

// Данные диалогового окна
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_SIGNALHASNOTBEENDETECTED_DIALOG };
#endif

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
	Drawer PC_SIGNAL;
	Drawer PC_ERROR;
	double value_frequency_1;
	double value_frequency_2;
	double value_frequency_3;
	int value_duration;
//	double value_border_1;
	int value_border_2;
	int value_border_1;
	afx_msg void OnBnClickedButton1();
//	double Scaning_Frequency;
//	BOOL Noise_Mod;
	BOOL Noise_Mod;
//	double value_scaning_frequency;
	double value_frequency_scan;
	double Noise_Energy_Percentage;
	int value_border_1_result;
	int value_border_2_result;
//	double value_window_length;
	BOOL auto_win_length_mod;
	int value_window_length;
	double value_evaluation_threshold;
};
