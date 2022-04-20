// See https://aka.ms/new-console-template for more information
using RubiksCubeTest;
using RubiksCubeTest.Controller;

var controller = new CubeController();
controller.PrintCube();
controller.Rotate(FaceLocation.Back, 1, "ClockWise");
controller.PrintCube();