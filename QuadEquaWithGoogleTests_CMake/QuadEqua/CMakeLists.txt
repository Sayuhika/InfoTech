﻿# CMakeList.txt: проект CMake для QuadEquaWithGoogleTests; включите исходный код и определения,
# укажите здесь логику для конкретного проекта.
#
cmake_minimum_required (VERSION 3.8)

# Добавьте источник в исполняемый файл этого проекта.
add_executable (QuadEquaWithGoogleTests "QuadEqua.cpp" "QuadEqua.h" "QESolver.cpp")
add_library (QuadEquaLib "QuadEqua.h" "QESolver.cpp")

if (CMAKE_VERSION VERSION_GREATER 3.12)
  set_property(TARGET QuadEquaWithGoogleTests PROPERTY CXX_STANDARD 20)
endif()

# TODO: Добавьте тесты и целевые объекты, если это необходимо.
