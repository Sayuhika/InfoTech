
// ConvolutionMFCDlg.cpp : файл реализации
//

#include "stdafx.h"
#include "ConvolutionMFC.h"
#include "ConvolutionMFCDlg.h"
#include "afxdialogex.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// диалоговое окно CConvolutionMFCDlg



CConvolutionMFCDlg::CConvolutionMFCDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CConvolutionMFCDlg::IDD, pParent)
	, GC_amplitude_1(4)
	, GC_amplitude_2(2)
	, GC_amplitude_3(3.5)
	, GC_meanv_1(8)
	, GC_meanv_2(30)
	, GC_meanv_3(40)
	, GC_deviation_1(4)
	, GC_deviation_2(3)
	, GC_deviation_3(5)
	, Imp_amplitude(1)
	, Imp_deviation(3)
	, Noise_power_percentage(20)
	, Precision(1.e-6f)
	, Signal_length(50)
	, Impulse_length(50)
	, noiseMode(FALSE)
	, inputError(0)
	, outputError(0)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CConvolutionMFCDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT1, GC_amplitude_1);
	DDX_Text(pDX, IDC_EDIT4, GC_amplitude_2);
	DDX_Text(pDX, IDC_EDIT7, GC_amplitude_3);
	DDX_Text(pDX, IDC_EDIT2, GC_meanv_1);
	DDX_Text(pDX, IDC_EDIT5, GC_meanv_2);
	DDX_Text(pDX, IDC_EDIT8, GC_meanv_3);
	DDX_Text(pDX, IDC_EDIT3, GC_deviation_1);
	DDX_Text(pDX, IDC_EDIT6, GC_deviation_2);
	DDX_Text(pDX, IDC_EDIT9, GC_deviation_3);
	DDX_Text(pDX, IDC_EDIT10, Imp_amplitude);
	DDX_Text(pDX, IDC_EDIT11, Imp_deviation);
	DDX_Text(pDX, IDC_EDIT12, Noise_power_percentage);
	DDX_Text(pDX, IDC_EDIT15, Precision);
	DDX_Text(pDX, IDC_EDIT13, Signal_length);
	DDX_Text(pDX, IDC_EDIT14, Impulse_length);
	DDX_Control(pDX, IDC_SIGNAL_PC, drawerSignal);
	DDX_Control(pDX, IDC_IMPRES_PC, drawerImpRes);
	DDX_Control(pDX, IDC_CONVOLUTION_PC, drawerConvolution);
	DDX_Check(pDX, IDC_CHECK1, noiseMode);
	DDX_Text(pDX, IDC_EDIT16, inputError);
	DDX_Text(pDX, IDC_EDIT17, outputError);
}

BEGIN_MESSAGE_MAP(CConvolutionMFCDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON_DROW, &CConvolutionMFCDlg::OnBnClickedButtonDrow)
	ON_BN_CLICKED(IDC_BUTTON_START, &CConvolutionMFCDlg::OnBnClickedButtonStart)
	ON_BN_CLICKED(IDC_BUTTON_STOP, &CConvolutionMFCDlg::OnBnClickedButtonStop)
	ON_WM_TIMER()
END_MESSAGE_MAP()


// обработчики сообщений CConvolutionMFCDlg

BOOL CConvolutionMFCDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Задает значок для этого диалогового окна.  Среда делает это автоматически,
	//  если главное окно приложения не является диалоговым
	SetIcon(m_hIcon, TRUE);			// Крупный значок
	SetIcon(m_hIcon, FALSE);		// Мелкий значок

	// TODO: добавьте дополнительную инициализацию
	SetTimer(1, USER_TIMER_MINIMUM, NULL);
	theApp.TAU = Precision;

	return TRUE;  // возврат значения TRUE, если фокус не передан элементу управления
}

// При добавлении кнопки свертывания в диалоговое окно нужно воспользоваться приведенным ниже кодом,
//  чтобы нарисовать значок.  Для приложений MFC, использующих модель документов или представлений,
//  это автоматически выполняется рабочей областью.

void CConvolutionMFCDlg::OnPaint()
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
HCURSOR CConvolutionMFCDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CConvolutionMFCDlg::OnBnClickedButtonDrow()
{
	UpdateData(TRUE);
	srand(time(0));
	Signal_values.clear(); Impulse_values.clear(); Convolution_values.clear();

	// Создаем отсчеты сигнала из Гауссовских куполов
	for (int i = 0; i < Signal_length;i++) {

		double GS1 = GC_amplitude_1 * exp(-0.5 * (i - GC_meanv_1) * (i - GC_meanv_1) / (GC_deviation_1 * GC_deviation_1));
		double GS2 = GC_amplitude_2 * exp(-0.5 * (i - GC_meanv_2) * (i - GC_meanv_2) / (GC_deviation_2 * GC_deviation_2));
		double GS3 = GC_amplitude_3 * exp(-0.5 * (i - GC_meanv_3) * (i - GC_meanv_3) / (GC_deviation_3 * GC_deviation_3));

		Signal_values.push_back(GS1 + GS2 + GS3);
	}

	// Создаем отсчеты импульсной характеристики
	if (Signal_length == Impulse_length) {
		for (int i = 0; i < Impulse_length;i++) {

			double GSIL = Imp_amplitude * exp(-0.5 * (i) * (i) / (Imp_deviation * Imp_deviation));
			double GSIR = Imp_amplitude * exp(-0.5 * (i - Impulse_length + 1) * (i - Impulse_length + 1) / (Imp_deviation * Imp_deviation));

			Impulse_values.push_back(GSIL + GSIR);
		}
	}
	else {
		vector<double> GS;
		for (int i = 0; i < Impulse_length;i++) {

			GS.push_back(Imp_amplitude * exp(-0.5 * (i) * (i) / (Imp_deviation * Imp_deviation)));
			//GSIR.push_back(Imp_amplitude * exp(-0.5 * (i - Impulse_length + 1) * (i - Impulse_length + 1) / (Imp_deviation * Imp_deviation)));
		}
		for (int i = 0; i < Signal_length - Impulse_length;i++) {
			GS.push_back(0);
		}
		for (int i = 0; i < Signal_length;i++) {
			Impulse_values.push_back(GS[i] + GS[Signal_length - i - 1]);
		}	
	}
	

	// Свертка
	Convolution_values = Convolution(Signal_values, Impulse_values);

	// Добавляем шум, если нужно
	if (noiseMode) 
	{
		double E = 0;
		
		for (int i = 0; i < Convolution_values.size();i++) {
			E += Convolution_values[i] * Convolution_values[i];
		}

		for (int i = 0; i < Convolution_values.size();i++) {

			double sum = 0;
			for (int j = 0; j < 12; j++) { sum += rand(); };
			sum /= (12 * RAND_MAX);
			sum -= 0.5;
			sum *= E * Noise_power_percentage * 0.01 / Convolution_values.size();

			if (Convolution_values[i] + sum > 0) {
				Convolution_values[i] += sum;
			}
			else {
				Convolution_values[i] -= sum;
			}
		}
	}

	// Отрисовка

	drawerSignal.SetData(&Signal_values, &Signal_values);
	drawerImpRes.SetData(&Impulse_values, &Impulse_values);
	drawerConvolution.SetData(&Convolution_values, &Convolution_values);
}

DWORD WINAPI ThreadJob(LPVOID param) {
	MHJ *Processor = (MHJ*)param;

	while (Processor->iterate(&theApp.functionalValue, &theApp.TAU)) {
		if (theApp.stopDeconvolutionFlag) {
			break;
		}
	}
	return 0;
}

void CConvolutionMFCDlg::OnBnClickedButtonStart()
{
	if (Signal_values.size() <= 0) {
		MessageBox(L"Push button \"Draw Signal\" first", L"WARNING");
	}
	else {
		DeSignal_values.clear(); DeConvolution_values.clear();

		theApp.stopDeconvolutionFlag = false;

		if (Processor != NULL) {
			delete Processor;
		}

		Processor = new MHJ;

		Processor->signal = Signal_values;
		Processor->impsig = Impulse_values;
		Processor->convolution = Convolution_values;

		Processor->init();
		DWORD dwThreadID;

		CreateThread(NULL, 0, &ThreadJob, (LPVOID)Processor, 0, &dwThreadID);
	}
}

void CConvolutionMFCDlg::OnBnClickedButtonStop()
{
	theApp.stopDeconvolutionFlag = true;
}

void CConvolutionMFCDlg::OnTimer(UINT_PTR nIDEvent)
{
	if (!theApp.stopDeconvolutionFlag) {
		DeSignal_values = MHJ::recsignal(Processor->signal, Impulse_values);
		DeConvolution_values = Convolution(DeSignal_values, Impulse_values);

		drawerSignal.SetData(&Signal_values, &DeSignal_values);
		drawerConvolution.SetData(&Convolution_values, &DeConvolution_values);

		outputError = theApp.functionalValue;
		inputError = 0;
		for (int i = 0; i < DeSignal_values.size(); i++) {
			inputError += (Signal_values[i] - DeSignal_values[i])*(Signal_values[i] - DeSignal_values[i]);
		}
		inputError /= Signal_values.size();

		UpdateData(FALSE);
	}

	CDialogEx::OnTimer(nIDEvent);
}
