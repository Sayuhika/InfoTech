#pragma once
#include <afxdialogex.h>
#include "Drawer.h"

class CMR_TDlg :
	public CDialogEx
{
public:
	CMR_TDlg(double amplitude_value, double frequency_value, double frequency_of_d_value, double omega_max_value, double omega_min_value, double omega_delta_value, double dooms, double T_value, double times_value, bool graph_mod, CWnd* pParent = nullptr);
	virtual ~CMR_TDlg();
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_MR_DIALOG };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// поддержка DDX/DDV
	virtual BOOL OnInitDialog();

public:
	Drawer DRAWMR_ER;
	double amplitude_value, frequency_value, omega_max_value, omega_min_value, omega_delta_value, dooms, T_value, times_value, frequency_of_d_value;
	bool graph_mod;
};

