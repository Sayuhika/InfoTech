
// SignalHasNotBeenDetectedDlg.cpp: файл реализации
//

#include "stdafx.h"
#include "SignalHasNotBeenDetected.h"
#include "SignalHasNotBeenDetectedDlg.h"
#include "afxdialogex.h"
#include "Creator.h"
#include "AutoRegression.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// Диалоговое окно CSignalHasNotBeenDetectedDlg



CSignalHasNotBeenDetectedDlg::CSignalHasNotBeenDetectedDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_SIGNALHASNOTBEENDETECTED_DIALOG, pParent)
	, value_frequency_1(0.08)
	, value_frequency_2(0.04)
	, value_frequency_3(0.12)
	, value_duration(250)
	, value_border_1(80)
	, value_border_2(190)
	, Noise_Mod(FALSE)
	, value_frequency_scan(0.04)
	, Noise_Energy_Percentage(0.03)
	, value_border_1_result(0)
	, value_border_2_result(0)
	, value_window_length(6)
	, auto_win_length_mod(TRUE)
	, value_evaluation_threshold(0.05)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CSignalHasNotBeenDetectedDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_PC_SIGNAL, PC_SIGNAL);
	DDX_Control(pDX, IDC_PC_ERROR, PC_ERROR);
	DDX_Text(pDX, IDC_FREQUENCY_1, value_frequency_1);
	DDX_Text(pDX, IDC_FREQUENCY_2, value_frequency_2);
	DDX_Text(pDX, IDC_FREQUENCY_3, value_frequency_3);
	DDX_Text(pDX, IDC_DURATION, value_duration);
	DDX_Text(pDX, IDC_BORDER_1, value_border_1);
	DDX_Text(pDX, IDC_BORDER_2, value_border_2);
	DDX_Check(pDX, IDC_CHECK1, Noise_Mod);
	DDX_Text(pDX, IDC_FREQUENCY_4, value_frequency_scan);
	DDX_Text(pDX, IDC_NE, Noise_Energy_Percentage);
	DDX_Text(pDX, IDC_BORDER_1R, value_border_1_result);
	DDX_Text(pDX, IDC_BORDER_2R, value_border_2_result);
	//  DDX_Text(pDX, IDC_WL, value_window_length);
	DDX_Check(pDX, IDC_CHECK2, auto_win_length_mod);
	DDX_Text(pDX, IDC_WL, value_window_length);
	DDX_Text(pDX, IDC_WL2, value_evaluation_threshold);
}

BEGIN_MESSAGE_MAP(CSignalHasNotBeenDetectedDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, &CSignalHasNotBeenDetectedDlg::OnBnClickedButton1)
END_MESSAGE_MAP()


// Обработчики сообщений CSignalHasNotBeenDetectedDlg

BOOL CSignalHasNotBeenDetectedDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Задает значок для этого диалогового окна.  Среда делает это автоматически,
	//  если главное окно приложения не является диалоговым
	SetIcon(m_hIcon, TRUE);			// Крупный значок
	SetIcon(m_hIcon, FALSE);		// Мелкий значок

	// TODO: добавьте дополнительную инициализацию

	return TRUE;  // возврат значения TRUE, если фокус не передан элементу управления
}

// При добавлении кнопки свертывания в диалоговое окно нужно воспользоваться приведенным ниже кодом,
//  чтобы нарисовать значок.  Для приложений MFC, использующих модель документов или представлений,
//  это автоматически выполняется рабочей областью.

void CSignalHasNotBeenDetectedDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // контекст устройства для рисования

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Выравнивание значка по центру клиентского прямоугольника
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Нарисуйте значок
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// Система вызывает эту функцию для получения отображения курсора при перемещении
//  свернутого окна.
HCURSOR CSignalHasNotBeenDetectedDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}




void CSignalHasNotBeenDetectedDlg::OnBnClickedButton1()
{
	UpdateData(TRUE);

	AutoRegression Prob;
	double phase(rand());
	vector<double> Noise_Signal;

	vector<double>  Signal = (CreateSignal(value_frequency_1, value_frequency_2, value_frequency_3, value_duration + 1, value_border_1, value_border_2, phase));
	if (Noise_Mod)
	{
		Noise_Signal = DoSomeNoiseWithSignal(&Signal, Noise_Energy_Percentage);
	}
	else
	{
		Noise_Signal = Signal;
	}
	PC_SIGNAL.SetData(&Signal, &Noise_Signal);

	vector<double> Errors = Prob.Errors(&Noise_Signal, value_frequency_scan);

	if (auto_win_length_mod)
	{
		value_window_length = (int) 1 / value_frequency_scan;
	}
	vector<double> FlatErrors = Prob.FlatErrors(&Errors, value_window_length);

	PC_ERROR.SetData(&Errors, &FlatErrors);

	double DeepFlag = theApp.FindMaxValue(&FlatErrors) * value_evaluation_threshold;
	int i = 0;
	while ((i < value_duration) && (FlatErrors[i] > DeepFlag) )
	{
		i++;
	}
	value_border_1_result = i;
	i++;

	while ((i < value_duration)&&(FlatErrors[i] < DeepFlag))
	{
		i++;
	}
	value_border_2_result = i;

	UpdateData(FALSE);
}
