// Drawer.cpp: файл реализации
//

#include "stdafx.h"
#include "ConvolutionMFC.h"
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
	Graphics Gr_(lpDrawItemStruct->hDC);
	Bitmap BM(lpDrawItemStruct->rcItem.right - lpDrawItemStruct->rcItem.left + 1.0f,
		lpDrawItemStruct->rcItem.bottom - lpDrawItemStruct->rcItem.top + 1.0f, &Gr_);
	Graphics Gr(&BM);
	Gr.SetSmoothingMode(SmoothingModeAntiAlias);
	Gr.Clear(Color::White);
	float free_place_kof = 95;
	float Kof_M = A_1.size() - 1.0f;

	double MAX_A = max(theApp.FindMaxValue(&A_1), theApp.FindMaxValue(&A_2));

	float kof_x_transform = (lpDrawItemStruct->rcItem.right - lpDrawItemStruct->rcItem.left + 1.0f - free_place_kof) / Kof_M;
	float kof_y_transform = (lpDrawItemStruct->rcItem.bottom - lpDrawItemStruct->rcItem.top + 1.0f - free_place_kof) / (MAX_A);
	Matrix M;
	M.Translate(free_place_kof / 2, free_place_kof / 2);
	M.Scale(kof_x_transform, -kof_y_transform);
	M.Translate(0.0f, -MAX_A);
	Gr.SetTransform(&M);
	Pen Aqua_Pen(Color::Blue, -1.0f);
	Pen Darkness_Pen(Color::Yellow, -1.0f);
	Pen Megumin_Pen(Color::Red, -1.0f);
	Pen YunYun_Pen(Color::LightGray, -1.0f);
	SolidBrush Wiz(Color::Black);

	// Отрисовка сетки
	int greed_size = 10;
	float delta_x_greed = Kof_M / (float)greed_size;
	float delta_y_greed = MAX_A / (float)greed_size;

	// (Создание шрифта)
	FontFamily fontFamily(L"Arial");
	Gdiplus::Font font(&fontFamily, 12, FontStyleRegular, UnitPixel);

	for (int i = 0; i <= greed_size; i++)
	{
		float x = i * delta_x_greed;
		float y = i * delta_y_greed;
		Gr.DrawLine(&YunYun_Pen, x, 0., x, MAX_A);
		Gr.DrawLine(&YunYun_Pen, 0., y, Kof_M, y);

		Gr.ResetTransform();

		CString str_x, str_y;
		str_x.Format(L"%.2f", x);
		str_y.Format(L"%.2f", y);

		PointF x_cor(x, 0), y_cor(0, y);

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

	//Отрисовка графика

	if (A_1.size() > 0) {
		PointF* Plot1 = new PointF[A_1.size()];

		for (int i = 0; i < A_1.size(); i++)
		{
			Plot1[i] = PointF(i, A_1[i]);
			
		}

		Gr.DrawCurve(&Megumin_Pen, Plot1, A_1.size());
	}
	

	if (A_2.size() > 0) {
		PointF* Plot2 = new PointF[A_2.size()];

		for (int i = 0; i < A_2.size(); i++)
		{
			Plot2[i] = PointF(i, A_2[i]);

		}

		Gr.DrawCurve(&Aqua_Pen, Plot2, A_2.size());
	}
	

	Gr_.DrawImage(&BM, 0, 0);
}
