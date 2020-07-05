CREATE TABLE Evaluacion
(	
	evaluacionId			INT				IDENTITY(1,1) PRIMARY KEY,
	notaCCQT				INT,
	notasLaboratorios		NVARCHAR(250),
	notaLabs				INT,
	notasExamenes			NVARCHAR(250),
	notaParciales			INT,
	notasTareas				NVARCHAR(250),
	notasComprobaciones		NVARCHAR(250),
	notasExamenesCortos		NVARCHAR(250),
	notasClases				NVARCHAR(250),
	participacionForos		INT,
	notaInvestigacion		INT,
	notaPlanificacion		INT,
	notaPresentacion		INT,
	notaEjecucionReporte	INT,
	notaVideo				INT,
);