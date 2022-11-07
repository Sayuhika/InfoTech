// Drawer.cpp: файл реализации
//

#include "stdafx.h"
#include "Telegraph.h"
#include "Drawer.h"

using namespace Gdiplus;

// Drawer

IMPLEMENT_DYNAMIC(Drawer, CStatic)

Drawer::Drawer()
{
	GdiplusStartupInput input;
	Status status = GdiplusStartup(&token, &input, NULL);
	if (status != Ok) { MessageBox(L"Error", L"Is Done", MB_OK | MB_ICONERROR); };
}

Drawer::~Drawer()
{
	GdiplusShutdown(token);
}


BEGIN_MESSAGE_MAP(Drawer, CStatic)
END_MESSAGE_MAP()



// Обработчики сообщений Drawer

void Drawer::DrawItem(LPDRAWITEMSTRUCT lpDrawItemStruct)
{
	//////////////////////////////////////////////////////////////////////////
	// В зависимости от принятого draw_mod, будет рисовать различные графики
	//
	// Рисование спектра:
	// draw_mod = 0 
	//
	// Рисование одного графика:
	// draw_mod = 1
	//
	// Рисование множества графиков:
	// draw_mod = 2
	//
	//////////////////////////////////////////////////////////////////////////

	Graphics Gr_(lpDrawItemStruct->hDC);
	Bitmap BM(lpDrawItemStruct->rcItem.right - lpDrawItemStruct->rcItem.left + 1.0f,
		lpDrawItemStruct->rcItem.bottom - lpDrawItemStruct->rcItem.top + 1.0f, &Gr_);
	Graphics Gr(&BM);
	Gr.SetSmoothingMode(SmoothingModeAntiAlias);
	Gr.Clear(Color::White);
	float free_place_kof = 95;
	float Kof_M, MAX_A(0);
	
	if (draw_mod == 2) 
	{
		Kof_M = signal_data_mult[0].back();
		for (int j = 1; j < signal_data_mult.size(); j++)
		{
			MAX_A = max(MAX_A,theApp.FindMaxValue(&signal_data_mult[j]));
		}
	}	
	else
	{
		Kof_M = signal_data.size() - 1.0f;
		MAX_A = theApp.FindMaxValue(&signal_data);
	}

	float kof_x_transform = (lpDrawItemStruct->rcItem.right - lpDrawItemStruct->rcItem.left + 1.0f - free_place_kof) / Kof_M;
	float kof_y_transform = (lpDrawItemStruct->rcItem.bottom - lpDrawItemStruct->rcItem.top + 1.0f - free_place_kof) / ((1.0f + (draw_mod == 1)) * MAX_A);

	Matrix M;
	M.Translate(free_place_kof / 2, free_place_kof / 2);
	M.Scale(kof_x_transform, -kof_y_transform);
	
	M.Translate(0.0f, -MAX_A);
	
	Gr.SetTransform(&M);
	Pen Aqua_Pen(Color::Aqua, -1.0f);
	Pen Darkness_Pen(Color::Yellow, -1.0f);
	Pen Megumin_Pen(Color::Red, -1.0f);
	Pen YunYun_Pen(Color::LightGray, -1.0f);
	SolidBrush Wiz(Color::Black);

	// Отрисовка сетки
	int greed_size = 10;
	float delta_x_greed = Kof_M / (float)greed_size;
	float delta_y_greed = (1.0f + (draw_mod == 1)) * MAX_A / (float)greed_size;

	// (Создание шрифта)
	FontFamily fontFamily(L"Arial");
	Gdiplus::Font font(&fontFamily, 12, FontStyleRegular, UnitPixel);

	for (int i = 0; i <= greed_size; i++)
	{
		float x = i * delta_x_greed;
		float y = i * delta_y_greed - MAX_A * (draw_mod == 1);
		Gr.DrawLine(&YunYun_Pen, x, -MAX_A * (draw_mod == 1), x, MAX_A);
		Gr.DrawLine(&YunYun_Pen, 0., y, Kof_M, y);

		Gr.ResetTransform();

		CString str_x, str_y;
		switch (draw_mod)
		{
			case 0 :
				str_x.Format(L"%.3f", x / (2*signal_data.size()));
				break;
			case 1:
				str_x.Format(L"%.3f", x);
				break;
			case 2:
				str_x.Format(L"%.3f", x);
				break;
		}
		str_y.Format(L"%.3f", y);

		PointF x_cor(x, -MAX_A * (draw_mod==1)), y_cor(0, y);

		M.TransformPoints(&x_cor);
		M.TransformPoints(&y_cor);

		y_cor.X -= 45;
		y_cor.Y -= 10;
		x_cor.X -= 16;
		x_cor.Y += 10;

		Gr.DrawString(str_x, -1, &font, x_cor, &Wiz);
		Gr.DrawString(str_y, -1, &font, y_cor, &Wiz);

		Gr.SetTransform(&M);
	}

	srand(time(0));

	//Отрисовка графика
	if (draw_mod == 2)
	{
		int n = signal_data_mult[0].size();

		for (int k = 1; k < signal_data_mult.size(); k++)
		{
			PointF* Plot = new PointF[n];

			for (int i = 0; i < n; i++)
			{
				Plot[i] = PointF(signal_data_mult[0][i], signal_data_mult[k][i]);
			}

			Gr.DrawCurve(&Pen(Color::MakeARGB(255, 255*rand()/RAND_MAX, 255 * rand() / RAND_MAX, 255 * rand() / RAND_MAX), -1.0f), Plot, n);
		}
	}
	else
	{
		int n = signal_data.size();

		PointF* Plot = new PointF[n];

		for (int i = 0; i < n; i++)
		{
			Plot[i] = PointF(i, signal_data[i]);
		}

		Gr.DrawCurve(&Megumin_Pen, Plot, n);
	}
	Gr_.DrawImage(&BM, 0, 0);
}
