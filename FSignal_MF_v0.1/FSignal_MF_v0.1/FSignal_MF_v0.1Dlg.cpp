
// FSignal_MF_v0.1Dlg.cpp: файл реализации
//

#include "stdafx.h"
#include "FSignal_MF_v0.1.h"
#include "FSignal_MF_v0.1Dlg.h"
#include "afxdialogex.h"
#include "Function_Fourier.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// Объявляем необходимые величины
vector<double> Time_data, Time_S_data, Standart_Signal_A_data, Noisy_Signal_A_data, Cleaned_Signal_A_data, Rand_Noise, Spectra_Modules_data, Cleaned_Spectra_Modules_data;
vector<complex<double>> Signal_Spectr_A_data, Signal_Spectr_AP_A_data;

double Signal_Energy, Noise_Energy, Spectrum_Energy, k, sum, MAX_Modul_Spectr, Enough_Spectrum_Energy;
const double PI = 3.141592653589793238463;

// Диалоговое окно CAboutDlg используется для описания сведений о приложении

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Данные диалогового окна
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_ABOUTBOX };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // поддержка DDX/DDV

// Реализация
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(IDD_ABOUTBOX)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// Диалоговое окно CFSignalMFv01Dlg



CFSignalMFv01Dlg::CFSignalMFv01Dlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_FSIGNAL_MF_V01_DIALOG, pParent)
	, Amplitude_1(1)
	, Amplitude_2(2)
	, Amplitude_3(3)
	, Frequency_1(0.03)
	, Frequency_2(0.02)
	, Frequency_3(0.01)
	, Noise_Energy_Percentage(40)
	, Residual_Signal_Energy_Percentage(28)
	, Signal_Duration(256)
	, Phase_1(0)
	, Phase_2(0)
	, Phase_3(0)
	, residual_value(0)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CFSignalMFv01Dlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT1, Amplitude_1);
	DDX_Text(pDX, IDC_EDIT4, Amplitude_2);
	DDX_Text(pDX, IDC_EDIT7, Amplitude_3);
	DDX_Text(pDX, IDC_EDIT2, Frequency_1);
	DDX_Text(pDX, IDC_EDIT5, Frequency_2);
	DDX_Text(pDX, IDC_EDIT8, Frequency_3);
	DDX_Text(pDX, IDC_EDIT3, Noise_Energy_Percentage);
	DDX_Text(pDX, IDC_EDIT6, Residual_Signal_Energy_Percentage);
	DDX_Text(pDX, IDC_EDIT9, Signal_Duration);
	DDX_Text(pDX, IDC_EDIT10, Phase_1);
	DDX_Text(pDX, IDC_EDIT11, Phase_2);
	DDX_Text(pDX, IDC_EDIT12, Phase_3);
	DDX_Text(pDX, IDC_EDIT13, residual_value);
}

BEGIN_MESSAGE_MAP(CFSignalMFv01Dlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_EN_CHANGE(IDC_EDIT6, &CFSignalMFv01Dlg::OnEnChangeEdit6)
	ON_BN_CLICKED(IDC_BUTTON1, &CFSignalMFv01Dlg::OnBnClickedButton1)
END_MESSAGE_MAP()


// Обработчики сообщений CFSignalMFv01Dlg

BOOL CFSignalMFv01Dlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Добавление пункта "О программе..." в системное меню.

	// IDM_ABOUTBOX должен быть в пределах системной команды.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != nullptr)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Задает значок для этого диалогового окна.  Среда делает это автоматически,
	//  если главное окно приложения не является диалоговым
	SetIcon(m_hIcon, TRUE);			// Крупный значок
	SetIcon(m_hIcon, FALSE);		// Мелкий значок

	// Задаем указатели на фреймы для рисования
	Drawer_Purified_and_Normal_Graphs.Create(GetDlgItem(IDC_STATIC_1)->GetSafeHwnd());
	Drawer_Noisy_Graph.Create(GetDlgItem(IDC_STATIC_2)->GetSafeHwnd());
	Drawer_Spectra.Create(GetDlgItem(IDC_STATIC_3)->GetSafeHwnd());

	return TRUE;  // возврат значения TRUE, если фокус не передан элементу управления
}

void CFSignalMFv01Dlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// При добавлении кнопки свертывания в диалоговое окно нужно воспользоваться приведенным ниже кодом,
//  чтобы нарисовать значок.  Для приложений MFC, использующих модель документов или представлений,
//  это автоматически выполняется рабочей областью.

void CFSignalMFv01Dlg::OnPaint()
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
HCURSOR CFSignalMFv01Dlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CFSignalMFv01Dlg::OnEnChangeEdit6()
{
	// TODO:  Если это элемент управления RICHEDIT, то элемент управления не будет
	// send this notification unless you override the CDialogEx::OnInitDialog()
	// функция и вызов CRichEditCtrl().SetEventMask()
	// with the ENM_CHANGE flag ORed into the mask.

	// TODO:  Добавьте код элемента управления
}


void CFSignalMFv01Dlg::OnBnClickedButton1()
{
	// TODO: добавьте свой код обработчика уведомлений
	UpdateData(TRUE);

	// Очищаем вектора и значения
	Time_data.clear(); 
	Standart_Signal_A_data.clear();
	Noisy_Signal_A_data.clear();
	Cleaned_Signal_A_data.clear();
	Rand_Noise.clear();
	Signal_Spectr_A_data.clear();
	Spectra_Modules_data.clear();
	Signal_Spectr_AP_A_data.clear();
	Cleaned_Spectra_Modules_data.clear();
	Time_S_data.clear();

	k = sum = MAX_Modul_Spectr = Spectrum_Energy = Enough_Spectrum_Energy = residual_value = 0;

	// Генерируем новое семя для нового рандома
	srand(time(0));

	// Расчет значений
	double t = Signal_Duration;
	double Amplitude_MAX = Amplitude_1 + Amplitude_2 + Amplitude_3;

	// Начальные данные -------------------------------------------------------------------------------------------------------------начало

	Time_data.push_back(0);
	Standart_Signal_A_data.push_back(Amplitude_1 * cos(Phase_1) + Amplitude_2 * cos(Phase_2) + Amplitude_3 * cos(Phase_3));

	// Шум
	for (int j = 0; j < 12; j++) { sum += rand(); };
	Rand_Noise.push_back(sum / (12 * RAND_MAX) - 0.5);

	// Энергия
	Signal_Energy = Standart_Signal_A_data[0] * Standart_Signal_A_data[0];
	Noise_Energy = Rand_Noise[0] * Rand_Noise[0];

	// Начальные данные --------------------------------------------------------------------------------------------------------------конец

	Drawer_Purified_and_Normal_Graphs.DrawBasement();
	Drawer_Noisy_Graph.DrawBasement();
	Drawer_Spectra.DrawBasement();

	for (int i = 1; i < t; i++)
	{
		Time_data.push_back(i);
		Standart_Signal_A_data.push_back(Amplitude_1 * cos(2*PI*Frequency_1*i + Phase_1) + Amplitude_2 * cos(2 * PI*Frequency_2*i + Phase_2) + Amplitude_3 * cos(2 * PI*Frequency_3*i + Phase_3));
		
		// Генерация шума
		sum = 0;
		for (int j = 0; j < 12; j++) { sum += rand(); };
		Rand_Noise.push_back(sum/(12*RAND_MAX) - 0.5);

		// Расчет энергии сигнала и шума
		Signal_Energy += Standart_Signal_A_data[i] * Standart_Signal_A_data[i];
		Noise_Energy += Rand_Noise[i] * Rand_Noise[i];
	}

	// Расчет коэффициента 
	k = sqrt(Signal_Energy * Noise_Energy_Percentage / (100 * Noise_Energy));
	
	Noisy_Signal_A_data.push_back(Standart_Signal_A_data[0] + Rand_Noise[0] * k);
	Signal_Spectr_A_data.push_back(Noisy_Signal_A_data[0]);
	MAX_Modul_Spectr = 0;

	// Расчет зашумленного сигнала
	for (int i = 1; i < t; i++)
	{
		Noisy_Signal_A_data.push_back(Standart_Signal_A_data[i] + Rand_Noise[i]*k);
		Signal_Spectr_A_data.push_back(Noisy_Signal_A_data[i]);
	}

	// Древним заклятием активируем Фурье образование
	FFourier(Signal_Spectr_A_data, Signal_Spectr_A_data.size(), -1);

	// Нахождение модулей спектра / Кладем значения в новый вектор, который станет "очищенным" спектром
	for (int i = 0; i < t; i++)
	{
		Signal_Spectr_AP_A_data.push_back(Signal_Spectr_A_data[i]);
		Spectra_Modules_data.push_back(sqrt(Signal_Spectr_A_data[i].real() * Signal_Spectr_A_data[i].real() + Signal_Spectr_A_data[i].imag() * Signal_Spectr_A_data[i].imag()));
		if (Spectra_Modules_data[i] > MAX_Modul_Spectr) { MAX_Modul_Spectr = Spectra_Modules_data[i]; };
	}

	// Расчет энергии спектра
	for (int i = 0; i < t; i++)
	{
		Spectrum_Energy += Spectra_Modules_data[i] * Spectra_Modules_data[i];
	}

	// Этап очистки сигнала
	Spectrum_Energy = Spectrum_Energy * Residual_Signal_Energy_Percentage / 100;
	int i_ = 0;
	while (Spectrum_Energy > Enough_Spectrum_Energy)
	{
		Enough_Spectrum_Energy += Spectra_Modules_data[Spectra_Modules_data.size() / 2 -1 - i_] * Spectra_Modules_data[Spectra_Modules_data.size() / 2 -1 - i_] + Spectra_Modules_data[Spectra_Modules_data.size() / 2 + i_] * Spectra_Modules_data[Spectra_Modules_data.size() / 2 + i_];
		Signal_Spectr_AP_A_data[Spectra_Modules_data.size() / 2 - 1 - i_] = Signal_Spectr_AP_A_data[Spectra_Modules_data.size() / 2 + i_] = complex<double>(0, 0);
		i_++;
		if (i_ > Spectra_Modules_data.size() / 2 - 2) { break; };
	}

	// Нахождение модулей "очищенного" спектра
	for (int i = 0; i < t; i++)
	{
		Cleaned_Spectra_Modules_data.push_back(sqrt(Signal_Spectr_AP_A_data[i].real() * Signal_Spectr_AP_A_data[i].real()+ Signal_Spectr_AP_A_data[i].imag() * Signal_Spectr_AP_A_data[i].imag()));
	}

	// Обратное Фурье преобразование
	FFourier(Signal_Spectr_AP_A_data, Signal_Spectr_AP_A_data.size(), 1);

	// Заполнение вектора очищенного сигнала / Расчет невязок
	for (int i = 0; i < t; i++)
	{
		Cleaned_Signal_A_data.push_back(Signal_Spectr_AP_A_data[i].real());
		residual_value += (Standart_Signal_A_data[i] - Cleaned_Signal_A_data[i]) * (Standart_Signal_A_data[i] - Cleaned_Signal_A_data[i]);
		Time_S_data.push_back(i / t);
	}

	UpdateData(FALSE);

	// Рисуем графики
	Drawer_Purified_and_Normal_Graphs.DrawTwoGraphs(Standart_Signal_A_data, Cleaned_Signal_A_data, Time_data, Amplitude_MAX * (1 + Noise_Energy_Percentage / 100), -Amplitude_MAX * (1 + Noise_Energy_Percentage / 100), Signal_Duration, 0);
	Drawer_Noisy_Graph.DrawGraph(Noisy_Signal_A_data, Time_data, Amplitude_MAX * (1 + Noise_Energy_Percentage / 100), -Amplitude_MAX * (1 + Noise_Energy_Percentage / 100), Signal_Duration, 0);
	Drawer_Spectra.DrawSpectraGraphs(Spectra_Modules_data, Cleaned_Spectra_Modules_data, Time_S_data, MAX_Modul_Spectr, 0, 1, 0);
}
