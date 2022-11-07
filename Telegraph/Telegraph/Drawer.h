#pragma once

#include <gdiplus.h>

// Drawer

class Drawer : public CStatic
{
	DECLARE_DYNAMIC(Drawer)

public:
	Drawer();
	virtual ~Drawer();
	ULONG_PTR token;
	vector<double> signal_data;
	vector<vector<double>> signal_data_mult;
	short int draw_mod;

protected:
	DECLARE_MESSAGE_MAP()
public:
	virtual void DrawItem(LPDRAWITEMSTRUCT lpDrawItemStruct);

	void SetData(vector<double>* data, short int d_m)
	{
		signal_data = *data;
		draw_mod = d_m;
		Invalidate(FALSE);
	}

	void SetDataMult(vector<vector<double>>* data)
	{
		signal_data_mult = *data;
		draw_mod = 2;
		Invalidate(FALSE);
	}
};


	