CREATE TABLE Tiene
(
	carneEstudianteFK		NVARCHAR(6)		NOT NULL,
	evaluacionIdFK			INT				NOT NULL,
	notaCurso				INT,
CONSTRAINT PK_Tiene		PRIMARY KEY(carneEstudianteFK, evaluacionIdFK),
CONSTRAINT FK_Tiene_Estudiante FOREIGN KEY(carneEstudianteFK)
	REFERENCES Estudiante(carne)
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
CONSTRAINT FK_Tiene_Evaluacion FOREIGN KEY(evaluacionIdFK)
	REFERENCES Evaluacion(evaluacionId)
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
);