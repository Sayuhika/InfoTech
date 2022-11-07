#pragma once

using namespace std;

class Drawer
{
	// Прямоугольник области рисования.
	CRect frame;
	// Указатель на объект окна, обалсти рисования.
	CWnd * wnd;
	// Контекст рисования, привязанный к области рисования.
	CDC * dc;
	// Контекст рисования, привязанный к памяти.
	CDC memDC;
	// Память для контекста рисования memDC.
	CBitmap bmp;
	// Флаг для отслеживания состояния инициализации класса.
	bool init;
public:

	// Проинициализировать объект класса на основе HWND.
	void Create(HWND hWnd)
	{
		// Получаем указатель на окно.
		wnd = CWnd::FromHandle(hWnd);
		// Получаем прямоугольник окна.
		wnd->GetClientRect(frame);
		// Получаем контекст для рисования в этом окне.
		dc = wnd->GetDC();

		// Создаем буфер-контекст.
		memDC.CreateCompatibleDC(dc);
		// Создаем растр для контекста рисования.
		bmp.CreateCompatibleBitmap(dc, frame.Width(), frame.Height());
		// Выбираем растр для использования буфер-контекстом.
		memDC.SelectObject(&bmp);
		init = true;
	}

	//Рисуем сетку-заготовку для графиков
	void DrawBasement()
	{
		if (!init) return;

		CPen subgrid_pen(PS_DOT, 1, RGB(200, 200, 200));
		CPen grid_pen(PS_SOLID, 1, RGB(0, 0, 0));

		CFont font;
		font.CreateFontW(18, 0, 0, 0,
			FW_DONTCARE,
			FALSE,				// Курсив
			FALSE,				// Подчеркнутый
			FALSE,				// Перечеркнутый
			DEFAULT_CHARSET,	// Набор символов
			OUT_OUTLINE_PRECIS,	// Точность соответствия.	
			CLIP_DEFAULT_PRECIS,//  
			CLEARTYPE_QUALITY,	// Качество
			VARIABLE_PITCH,		//
			TEXT("Times New Roman")		//
		);

		int padding = 20;
		int left_keys_padding = 20;
		int bottom_keys_padding = 10;

		int actual_width = frame.Width() - 2 * padding - left_keys_padding;
		int actual_height = frame.Height() - 2 * padding - bottom_keys_padding;

		int actual_top = padding;
		int actual_bottom = actual_top + actual_height;
		int actual_left = padding + left_keys_padding;
		int actual_right = actual_left + actual_width;

		// Белый фон.
		memDC.FillSolidRect(frame, RGB(255, 255, 255));

		// Рисуем сетку и подсетку.
		unsigned int grid_size = 10;

		memDC.SelectObject(&subgrid_pen);

		for (double i = 0.5; i < grid_size; i += 1.0)
		{
			memDC.MoveTo(actual_left + i * actual_width / grid_size, actual_top);
			memDC.LineTo(actual_left + i * actual_width / grid_size, actual_bottom);
			memDC.MoveTo(actual_left, actual_top + i * actual_height / grid_size);
			memDC.LineTo(actual_right, actual_top + i * actual_height / grid_size);
		}

		memDC.SelectObject(&grid_pen);

		for (double i = 0.0; i < grid_size + 1; i += 1.0)
		{
			memDC.MoveTo(actual_left + i * actual_width / grid_size, actual_top);
			memDC.LineTo(actual_left + i * actual_width / grid_size, actual_bottom);
			memDC.MoveTo(actual_left, actual_top + i * actual_height / grid_size);
			memDC.LineTo(actual_right, actual_top + i * actual_height / grid_size);
		}
	}
	// Нарисовать график по переданным данным.
	void DrawGraph(vector<double> &data, vector<double> &keys, double y_max, double y_min, double x_max, double x_min)
	{
		if (!init) return;

		CPen data_pen(PS_SOLID, 2, RGB(255, 0, 0));
		CFont font;

		font.CreateFontW(18, 0, 0, 0,
			FW_DONTCARE,
			FALSE,				// Курсив
			FALSE,				// Подчеркнутый
			FALSE,				// Перечеркнутый
			DEFAULT_CHARSET,	// Набор символов
			OUT_OUTLINE_PRECIS,	// Точность соответствия.	
			CLIP_DEFAULT_PRECIS,//  
			CLEARTYPE_QUALITY,	// Качество
			VARIABLE_PITCH,		//
			TEXT("Times New Roman")		//
		);

		int padding = 20;
		int left_keys_padding = 20;
		int bottom_keys_padding = 10;

		int actual_width = frame.Width() - 2 * padding - left_keys_padding;
		int actual_height = frame.Height() - 2 * padding - bottom_keys_padding;

		int actual_top = padding;
		int actual_bottom = actual_top + actual_height;
		int actual_left = padding + left_keys_padding;
		int actual_right = actual_left + actual_width;

		unsigned int grid_size = 10;

		double data_y_max(y_max), data_y_min(y_min);
		double data_x_max(x_max), data_x_min(x_min);

		vector<double> y = convert_range(data, actual_top, actual_bottom, data_y_max, data_y_min);
		vector<double> x = convert_range(keys, actual_right, actual_left, data_x_max, data_x_min);

		memDC.SelectObject(&data_pen);

		memDC.MoveTo(x[0], y[0]);
		for (unsigned int i = 1; i < y.size(); i++)
		{
			memDC.LineTo(x[i], y[i]);
		}

		memDC.SelectObject(&font);
		memDC.SetTextColor(RGB(0, 0, 0));
		for (int i = 0; i < grid_size / 2 + 1; i++)
		{
			CString str;
			str.Format(L"%.1f", data_x_min + i * (data_x_max - data_x_min) / (grid_size / 2));
			memDC.TextOutW(actual_left + (double)i * actual_width / (grid_size / 2) - bottom_keys_padding, actual_bottom + bottom_keys_padding / 2, str);

			str.Format(L"%.2f", data_y_min + i * (data_y_max - data_y_min) / (grid_size / 2));
			memDC.TextOutW(actual_left - 1.5*left_keys_padding, actual_bottom - (double)i * actual_height / (grid_size / 2) - bottom_keys_padding, str);
		}

		dc->BitBlt(0, 0, frame.Width(), frame.Height(), &memDC, 0, 0, SRCCOPY);
	}

	void DrawTwoGraphs(vector<double> &data1, vector<double> &data2, vector<double> &keys, double y_max, double y_min, double x_max, double x_min)
	{
		if (!init) return;

		CPen data1_pen(PS_SOLID, 2, RGB(255, 0, 0));
		CPen data2_pen(PS_SOLID, 2, RGB(0, 0, 255));
		CFont font;

		font.CreateFontW(18, 0, 0, 0,
			FW_DONTCARE,
			FALSE,				// Курсив
			FALSE,				// Подчеркнутый
			FALSE,				// Перечеркнутый
			DEFAULT_CHARSET,	// Набор символов
			OUT_OUTLINE_PRECIS,	// Точность соответствия.	
			CLIP_DEFAULT_PRECIS,//  
			CLEARTYPE_QUALITY,	// Качество
			VARIABLE_PITCH,		//
			TEXT("Times New Roman")		//
		);

		int padding = 20;
		int left_keys_padding = 20;
		int bottom_keys_padding = 10;

		int actual_width = frame.Width() - 2 * padding - left_keys_padding;
		int actual_height = frame.Height() - 2 * padding - bottom_keys_padding;

		int actual_top = padding;
		int actual_bottom = actual_top + actual_height;
		int actual_left = padding + left_keys_padding;
		int actual_right = actual_left + actual_width;

		unsigned int grid_size = 10;

		double data_y_max(y_max), data_y_min(y_min);
		double data_x_max(x_max), data_x_min(x_min);

		vector<double> y1 = convert_range(data1, actual_top, actual_bottom, data_y_max, data_y_min);
		vector<double> y2 = convert_range(data2, actual_top, actual_bottom, data_y_max, data_y_min);
		vector<double> x = convert_range(keys, actual_right, actual_left, data_x_max, data_x_min);

		for (unsigned int i = 1; i < y1.size(); i++)
		{
			memDC.SelectObject(&data1_pen);
			memDC.MoveTo(x[i-1], y1[i-1]);
			memDC.LineTo(x[i], y1[i]);
			memDC.SelectObject(&data2_pen);
			memDC.MoveTo(x[i - 1], y2[i - 1]);
			memDC.LineTo(x[i], y2[i]);	
		}

		memDC.SelectObject(&font);
		memDC.SetTextColor(RGB(0, 0, 0));
		for (int i = 0; i < grid_size / 2 + 1; i++)
		{
			CString str;
			str.Format(L"%.1f", data_x_min + i * (data_x_max - data_x_min) / (grid_size / 2));
			memDC.TextOutW(actual_left + (double)i * actual_width / (grid_size / 2) - bottom_keys_padding, actual_bottom + bottom_keys_padding / 2, str);

			str.Format(L"%.2f", data_y_min + i * (data_y_max - data_y_min) / (grid_size / 2));
			memDC.TextOutW(actual_left - 1.5*left_keys_padding, actual_bottom - (double)i * actual_height / (grid_size / 2) - bottom_keys_padding, str);
		}

		dc->BitBlt(0, 0, frame.Width(), frame.Height(), &memDC, 0, 0, SRCCOPY);
	}

	void DrawSpectraGraphs(vector<double> &data1, vector<double> &data2, vector<double> &keys, double y_max, double y_min, double x_max, double x_min)
	{
		if (!init) return;

		CPen data1_pen(PS_SOLID, 2, RGB(255, 0, 0));
		CPen data2_pen(PS_SOLID, 2, RGB(0, 0, 255));
		CFont font;

		font.CreateFontW(18, 0, 0, 0,
			FW_DONTCARE,
			FALSE,				// Курсив
			FALSE,				// Подчеркнутый
			FALSE,				// Перечеркнутый
			DEFAULT_CHARSET,	// Набор символов
			OUT_OUTLINE_PRECIS,	// Точность соответствия.	
			CLIP_DEFAULT_PRECIS,//  
			CLEARTYPE_QUALITY,	// Качество
			VARIABLE_PITCH,		//
			TEXT("Times New Roman")		//
		);

		int padding = 20;
		int left_keys_padding = 20;
		int bottom_keys_padding = 10;

		int actual_width = frame.Width() - 2 * padding - left_keys_padding;
		int actual_height = frame.Height() - 2 * padding - bottom_keys_padding;

		int actual_top = padding;
		int actual_bottom = actual_top + actual_height;
		int actual_left = padding + left_keys_padding;
		int actual_right = actual_left + actual_width;

		unsigned int grid_size = 10;

		double data_y_max(y_max), data_y_min(y_min);
		double data_x_max(x_max), data_x_min(x_min);

		vector<double> y1 = convert_range(data1, actual_top, actual_bottom, data_y_max, data_y_min);
		vector<double> y2 = convert_range(data2, actual_top, actual_bottom, data_y_max, data_y_min);
		vector<double> x = convert_range(keys, actual_right, actual_left, data_x_max, data_x_min);

		for (unsigned int i = 1; i < y1.size(); i++)
		{
			memDC.SelectObject(&data1_pen);
			memDC.MoveTo(x[i - 1], y1[i - 1]);
			memDC.LineTo(x[i], y1[i]);
			memDC.SelectObject(&data2_pen);
			memDC.MoveTo(x[i - 1], y2[i - 1]);
			memDC.LineTo(x[i], y2[i]);
		}

		memDC.SelectObject(&font);
		memDC.SetTextColor(RGB(0, 0, 0));
		for (int i = 0; i < grid_size / 2 + 1; i++)
		{
			CString str;
			str.Format(L"%.1f", data_x_min + i * (data_x_max - data_x_min) / (grid_size / 2));
			memDC.TextOutW(actual_left + (double)i * actual_width / (grid_size / 2) - bottom_keys_padding, actual_bottom + bottom_keys_padding / 2, str);

			str.Format(L"%.2f", data_y_min + i * (data_y_max - data_y_min) / (grid_size / 2));
			memDC.TextOutW(actual_left - 1.5*left_keys_padding, actual_bottom - (double)i * actual_height / (grid_size / 2) - bottom_keys_padding, str);
		}

		dc->BitBlt(0, 0, frame.Width(), frame.Height(), &memDC, 0, 0, SRCCOPY);
	}

	vector<double> convert_range(vector <double> & data, double outmax, double outmin, double inmax, double inmin)
	{
		vector<double> output = data;
		double k = (outmax - outmin) / (inmax - inmin);
		for (auto & item : output)
		{
			item = (item - inmin) * k + outmin;
		}

		return output;
	}
};