if(EXISTS "D:/Documents/Visual Studio Projects/IT/QuadEquaWithGoogleTests/out/build/x64-debug/QuadEquaTest/QuadEquaTest[1]_tests.cmake")
  include("D:/Documents/Visual Studio Projects/IT/QuadEquaWithGoogleTests/out/build/x64-debug/QuadEquaTest/QuadEquaTest[1]_tests.cmake")
else()
  add_test(QuadEquaTest_NOT_BUILT QuadEquaTest_NOT_BUILT)
endif()
