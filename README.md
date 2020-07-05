# Curso---Tarea9y10
Calcular notas ingresadas con formulario 

1- Abrir con Visual Studio el archivo Notas.sln
2- Se utilizo un proyecto de datos (SQL Server Database Project) para tener una base dentro de la 
solucion 'Notas'. Este proyecto de la base se llama CursoDB.
3- Conectarse al servidor de su base local. Poner CursoDB como el nombre de la base.
4- Cambiar en <connectionStrings> "Data Source=(localdb)\MSSQLLocalDB;" por el data source de su 
base local. Este cambio se debe hacer en Web.config del proyecto Notas y en App.config en Notas.Tests.
6- Hacerle rebuild a los proyectos.
7- Seleccionar el proyecto CursoDB como el proyecto inicial () y darle run para hacerle Deploy.
Tres tablas debieron ser creadas Estudiante, Evaluacion y Tiene.
8- Volver a poner Notas como el startup project
9- Correr el proyecto.
10- Se deben agregar estudiantes al curso para calificarlos.
