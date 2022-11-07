
// TelegraphDlg.h: файл заголовка
//

#pragma once

#include "Drawer.h"


// Диалоговое окно CTelegraphDlg
class CTelegraphDlg : public CDialogEx
{
// Создание
public:
	CTelegraphDlg(CWnd* pParent = nullptr);	// стандартный конструктор

// Данные диалогового окна
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_TELEGRAPH_DIALOG };
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
	double omega_max_value;
	double omega_min_value;
	double omega_delta_value;
	afx_msg void OnBnClickedButton1();
	double amplitude_value;
	double frequency_value;
	int T_value;
	Drawer DWART_ER;
//	double frequency_of_d;
	double frequency_of_d_value;
	Drawer DWART_S_ER;
	afx_msg void OnBnClickedButton2();
	int times_value;
	double omega_test_value;
//	double omega_test_delta_value;
//	CString DF_res_value;
	double DF_res_value;
	BOOL graph_mod;
};
