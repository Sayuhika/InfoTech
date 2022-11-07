
// TelegraphDlg.cpp: файл реализации
//

#include "stdafx.h"
#include "Telegraph.h"
#include "TelegraphDlg.h"
#include "CMR_TDlg.h"
#include "afxdialogex.h"
#include "Creator.h"
#include "Function_Fourier.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// Диалоговое окно CTelegraphDlg



CTelegraphDlg::CTelegraphDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_TELEGRAPH_DIALOG, pParent)
	, omega_max_value(0.1)
	, omega_min_value(0.005)
	, omega_delta_value(0.001)
	, amplitude_value(5)
	, frequency_value(0.3)
	, T_value(32)
	, frequency_of_d_value(1)
	, times_value(5)
	, omega_test_value(0.1)
	, DF_res_value(0)
	, graph_mod(TRUE)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CTelegraphDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT2, omega_max_value);
	DDX_Text(pDX, IDC_EDIT3, omega_min_value);
	DDX_Text(pDX, IDC_EDIT4, omega_delta_value);
	DDX_Text(pDX, IDC_EDIT5, amplitude_value);
	DDX_Text(pDX, IDC_EDIT6, frequency_value);
	DDX_Text(pDX, IDC_EDIT1, T_value);
	DDX_Control(pDX, IDC_DWART, DWART_ER);
	DDX_Text(pDX, IDC_EDIT7, frequency_of_d_value);
	DDX_Control(pDX, IDC_DWART_S, DWART_S_ER);
	DDX_Text(pDX, IDC_EDIT8, times_value);
	DDX_Text(pDX, IDC_EDIT9, omega_test_value);
	//  DDX_Text(pDX, IDC_EDIT10, omega_test_delta_value);
	//  DDX_Text(pDX, IDC_EDIT10, DF_res_value);
	DDX_Text(pDX, IDC_EDIT10, DF_res_value);
	DDX_Check(pDX, IDC_CHECK1, graph_mod);
}

BEGIN_MESSAGE_MAP(CTelegraphDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, &CTelegraphDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CTelegraphDlg::OnBnClickedButton2)
END_MESSAGE_MAP()


// Обработчики сообщений CTelegraphDlg

BOOL CTelegraphDlg::OnInitDialog()
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

void CTelegraphDlg::OnPaint()
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
HCURSOR CTelegraphDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CTelegraphDlg::OnBnClickedButton1()
{
	UpdateData(TRUE);
	srand(time(0));

	// Начальные данные
	vector<int> T;
	int n_sdv = 1;
	int n_dv = 1;
	
	double phase = 2 * M_PI * (double)rand() / RAND_MAX;
	
	// Выбираем более подходящее значение длины битового массива относительно установленного пользователем
	while (T_value > n_sdv)
	{
		n_sdv *= 2;
	}
	T_value = n_sdv;

	// Выбираем более подходящее значение частоты дискретизации относительно установленного пользователем
	while (frequency_of_d_value > n_dv)
	{
		n_dv *= 2;
	}
	frequency_of_d_value = n_dv;

	int dooms = 32 * frequency_of_d_value;

	// Генерируем случайный битовый сигнал
	for (int i = 0; i < T_value; i++)
	{
		if (((double)rand() / RAND_MAX) < 0.5 )
		{
			T.push_back(0);
		}
		else 
		{
			T.push_back(1);
		}
	}

	vector<double> Signal = CreateSignal(amplitude_value, omega_test_value, frequency_value, frequency_of_d_value, phase, T_value, dooms, &T);
	vector<double> Spectra_Modules, Half_Spectra_Modules;
	vector<complex<double>> Signal_Spectr;

	// Создаем начальный массив для спектра
	for (int i = 0; i < Signal.size(); i++)
	{
		Signal_Spectr.push_back(Signal[i]);
	}

	// Древним заклятием активируем Фурье образование
	FFourier(Signal_Spectr, Signal_Spectr.size(), -1);

	// Нахождение модулей спектра
	for (int i = 0; i < Signal_Spectr.size(); i++)
	{
		Spectra_Modules.push_back(sqrt(Signal_Spectr[i].real() * Signal_Spectr[i].real() + Signal_Spectr[i].imag() * Signal_Spectr[i].imag()));
	}
	
	// Поиск размера ширины спектра
	double MAX_A = theApp.FindMaxValue(&Spectra_Modules);
	double Limit = MAX_A / 10;
	int flag_1(0), flag_2(Spectra_Modules.size() / 2);

	while (Spectra_Modules[flag_1] < Limit)
	{
		flag_1++;
		if (flag_1 > Spectra_Modules.size())
		{
			break;
		}
	}
	while (Spectra_Modules[flag_2] < Limit)
	{
		flag_2--;
		if (flag_2 == flag_1)
		{
			break;
		}
	}

	DF_res_value = frequency_of_d_value * (flag_2 - flag_1) / (double)Spectra_Modules.size();

	// Обрезаем половину спектра за ненадобностью
	for (int i = 0; i < Spectra_Modules.size() / 2; i++)
	{
		Half_Spectra_Modules.push_back(Spectra_Modules[i]);
	}
	
	// Рисуем графики
	DWART_ER.SetData(&Signal, 1);
	DWART_S_ER.SetData(&Half_Spectra_Modules, 0);

	UpdateData(FALSE);
}


void CTelegraphDlg::OnBnClickedButton2()
{
	UpdateData(TRUE);
	srand(time(0));

	int n_dv = 1;
	while (frequency_of_d_value > n_dv)
	{
		n_dv *= 2;
	}
	frequency_of_d_value = n_dv;

	int dooms = 32 * frequency_of_d_value;

	CMR_TDlg dlg(amplitude_value, frequency_value, frequency_of_d_value, omega_max_value, omega_min_value, omega_delta_value, dooms, T_value, times_value, graph_mod);
	theApp.m_pActiveWnd = &dlg;
	INT_PTR nResponse = dlg.DoModal();


	if (nResponse == IDOK)
	{
		// TODO: Введите код для обработки закрытия диалогового окна
		//  с помощью кнопки "ОК"
	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: Введите код для обработки закрытия диалогового окна
		//  с помощью кнопки "Отмена"
	}
	else if (nResponse == -1)
	{
		TRACE(traceAppMsg, 0, "Предупреждение. Не удалось создать диалоговое окно, поэтому работа приложения неожиданно завершена.\n");
		TRACE(traceAppMsg, 0, "Предупреждение. При использовании элементов управления MFC для диалогового окна невозможно #define _AFX_NO_MFC_CONTROLS_IN_DIALOGS.\n");
	}
	
}
