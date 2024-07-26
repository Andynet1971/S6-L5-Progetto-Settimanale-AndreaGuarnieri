CREATE TABLE Clienti (
    CodiceFiscale VARCHAR(16) PRIMARY KEY,
    Cognome NVARCHAR(50),
    Nome NVARCHAR(50),
    Citta NVARCHAR(50),
    Provincia NVARCHAR(50),
    Email NVARCHAR(100),
    Telefono NVARCHAR(20),
    Cellulare NVARCHAR(20)
);

CREATE TABLE Camere (
    Numero INT PRIMARY KEY,
    Descrizione NVARCHAR(100),
    Tipologia NVARCHAR(20) CHECK (Tipologia IN ('singola', 'doppia'))
);

CREATE TABLE Prenotazioni (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CodiceFiscale VARCHAR(16),
    NumeroCamera INT,
    DataPrenotazione DATE,
    NumeroProgressivo INT,
    Anno INT,
    DataInizio DATE,
    DataFine DATE,
    Caparra DECIMAL(10, 2),
    Tariffa DECIMAL(10, 2),
    TipoSoggiorno NVARCHAR(20) CHECK (TipoSoggiorno IN ('mezza pensione', 'pensione completa', 'pernottamento con prima colazione')),
    FOREIGN KEY (CodiceFiscale) REFERENCES Clienti(CodiceFiscale),
    FOREIGN KEY (NumeroCamera) REFERENCES Camere(Numero)
);

CREATE TABLE ServiziAggiuntivi (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    PrenotazioneID INT,
    Data DATE,
    Quantita INT,
    Prezzo DECIMAL(10, 2),
    Descrizione NVARCHAR(100),
    FOREIGN KEY (PrenotazioneID) REFERENCES Prenotazioni(ID)
);

CREATE TABLE Utenti (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE,
    PasswordHash NVARCHAR(255) -- Si assume che le password siano salvate in hash
);
