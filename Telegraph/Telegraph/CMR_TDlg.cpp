#include "stdafx.h"
#include "Telegraph.h"
#include "CMR_TDlg.h"
#include "afxdialogex.h"

vector<double> CreateSignal(double amplitude_value, double omega_value, double frequency_value, double frequency_of_d_value, double phase, double T_value, double dooms, vector<int>* T);
void FFourier(vector<complex<double>> &data, int n, int is);

CMR_TDlg::CMR_TDlg(double amplitude_value, double frequency_value, double frequency_of_d_value, double omega_max_value, double omega_min_value, double omega_delta_value, double dooms, double T_value, double times_value, bool graph_mod, CWnd* pParent /*=nullptr*/) : CDialogEx(IDD_MR_DIALOG, pParent)
{
	this->amplitude_value = amplitude_value;
	this->frequency_value = frequency_value; 
	this->frequency_of_d_value = frequency_of_d_value;
	this->omega_max_value = omega_max_value;
	this->omega_min_value = omega_min_value; 
	this->omega_delta_value = omega_delta_value;
	this->dooms = dooms;
	this->T_value = T_value;
	this->times_value = times_value;
	this->graph_mod = graph_mod;
}


CMR_TDlg::~CMR_TDlg()
{
}

void CMR_TDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_DRAWMR, DRAWMR_ER);
}

BOOL CMR_TDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	int m_n = (omega_max_value - omega_min_value) / omega_delta_value;
	srand(time(0));

	int n_sdv = 1;

	// Выбираем более подходящее значение длины битового массива относительно установленного пользователем
	while (T_value > n_sdv)
	{
		n_sdv *= 2;
	}
	T_value = n_sdv;

	vector<int> T;
	vector<vector<double>> delta_F_res(times_value+1);
	vector<vector<double>> delta_F_averaged_res(2);

	for (int i=0; i < m_n; i++)
	{
		double res = omega_min_value + omega_delta_value * i;

		delta_F_res[0].push_back(res);
		delta_F_averaged_res[0].push_back(res);
	}

	for (int m_i = 0; m_i < times_value; m_i++)
	{
		// Генерируем случайный битовый сигнал
		for (int i = 0; i < T_value; i++)
		{
			if (((double)rand() / RAND_MAX) < 0.5)
			{
				T.push_back(0);
			}
			else
			{
				T.push_back(1);
			}
		}
		for (int m_j = 0; m_j < m_n; m_j++)
		{
			double phase = 2 * M_PI * (double)rand() / RAND_MAX;

			// Выбираем более подходящее значение частоты дискретизации относительно установленного пользователем

			vector<double> Signal = CreateSignal(amplitude_value, delta_F_res[0][m_j], frequency_value, frequency_of_d_value, phase, T_value, dooms, &T);
			vector<double> Spectra_Modules;
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

			// Поиск delta F 
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

			delta_F_res[m_i + 1].push_back(frequency_of_d_value * (flag_2 - flag_1) / (double)Spectra_Modules.size());
		}
	}

	if (graph_mod)
	{
		// Усреднение:
		double averaged_sum;

		for (int m_i = 0; m_i < m_n; m_i++)
		{
			averaged_sum = 0;

			for (int m_j = 0; m_j < times_value; m_j++)
			{
				averaged_sum += delta_F_res[m_j + 1][m_i];
			}

			averaged_sum /= times_value;
			delta_F_averaged_res[1].push_back(averaged_sum);
		}

		// Построить усредненный график
		DRAWMR_ER.SetDataMult(&delta_F_averaged_res);
	}
	else
	{
		// Построить все графики
		DRAWMR_ER.SetDataMult(&delta_F_res);

	}

	return TRUE;
}