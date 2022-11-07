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

	vector<double> A_1, A_2;

protected:
	DECLARE_MESSAGE_MAP()
public:
	virtual void DrawItem(LPDRAWITEMSTRUCT /*lpDrawItemStruct*/);

	void SetData(vector<double>* data1, vector<double>* data2)
	{
		A_1 = *data1;
		A_2 = *data2;
		Invalidate(FALSE);
	}
};


