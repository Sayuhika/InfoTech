#include "pch.h"
#include <gtest/gtest.h>
#include "../QuadEqua/QuadEqua.h"

using namespace std;

class BasicTest : public ::testing::Test {
protected:
    unique_ptr<QESolver> Solver;
    void SetUp() override {
        Solver = unique_ptr<QESolver>(new QESolver());
    }
};

// D = 0
TEST_F(BasicTest, GetSolve_test1)
{
    complex<double> x1, x2;

    ASSERT_TRUE(Solver->SetParams(1, 2, 1));
    ASSERT_TRUE(Solver->GetSolve(x1, x2));

    EXPECT_EQ(x1, x2);
}

// D > 0
TEST_F(BasicTest, GetSolve_test2)
{
    complex<double> x1, x2;

    ASSERT_TRUE(Solver->SetParams(1, 100, 1));
    ASSERT_TRUE(Solver->GetSolve(x1, x2));

    EXPECT_EQ(((x1.imag() <= numeric_limits<double>::epsilon()) && (x2.imag() <= numeric_limits<double>::epsilon())), true);
}

// D < 0
TEST_F(BasicTest, GetSolve_test3)
{
    complex<double> x1, x2;

    ASSERT_TRUE(Solver->SetParams(1, -6, 13));
    ASSERT_TRUE(Solver->GetSolve(x1, x2));

    EXPECT_EQ(x1.real(), 3);
    EXPECT_EQ(x1.imag(), 2);

    EXPECT_EQ(x2.real(), 3);
    EXPECT_EQ(x2.imag(), -2);
}

// Не установлены параметры
TEST_F(BasicTest, GetSolve_test4)
{
    complex<double> x1, x2;

    EXPECT_EQ(Solver->GetSolve(x1, x2), false);
}

// Выход за границы double
TEST_F(BasicTest, GetSolve_test5)
{
    complex<double> x1, x2;

    ASSERT_TRUE(Solver->SetParams(numeric_limits<double>::max(), numeric_limits<double>::max(), numeric_limits<double>::max()));
    EXPECT_EQ(Solver->GetSolve(x1, x2), false);
}