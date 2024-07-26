La mia applicazione è strutturata in questo modo:

Appena lanciata l'app viene chiesto subito di fare il login senza il quale non è possibile effettuare nessuna operazione. Il login è implementato con l'algoritmo di criptazione della password PBKDF2. Tale algoritmo prevede oltra a Hash della password anche un valore Salt che viene generato automaticamente ed è univoco per ogni password. Per questo motivo ho creato una tabella all'interno del mio database per gestire gli utenti che è strutturata in questo modo:

CREATE TABLE [dbo].[Utenti] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (50)  NOT NULL,
    [PasswordHash] NVARCHAR (255) NOT NULL,
    [Salt]         NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);

Nel login si può implementare se salvare l'accesso per 30 minuti.
Se il login va a buon fine si avrà accesso a tutte le funzionalità dell'app altrimenti l'utente verrà rimandato ad una vista di login fallito.
Ho popolato la tabella con 2 utenti con le relative passwordHash e Salt e per fare ciò ho dovuto creare un piccolo script C# che mi genera a sua volta uno script sql per poter inserire i valori Hash e Salt criptati.

Per il resto dell'applicazione ho previsto 5 tabelle che riporto qui sotto:

CREATE TABLE [dbo].[Camere] (
    [Numero]             INT             NOT NULL,
    [Descrizione]        NVARCHAR (100)  NOT NULL,
    [Tipologia]          NVARCHAR (20)   NOT NULL,
    [TariffaGiornaliera] DECIMAL (10, 2) NOT NULL,
    [Disponibile]        BIT             DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Numero] ASC),
    CHECK ([Tipologia]='doppia' OR [Tipologia]='singola' OR [Tipologia]='suite')
);

CREATE TABLE [dbo].[Clienti] (
    [CodiceFiscale] VARCHAR (16)   NOT NULL,
    [Cognome]       NVARCHAR (50)  NOT NULL,
    [Nome]          NVARCHAR (50)  NOT NULL,
    [Citta]         NVARCHAR (50)  NOT NULL,
    [Provincia]     NVARCHAR (50)  NOT NULL,
    [Email]         NVARCHAR (100) NOT NULL,
    [Telefono]      NVARCHAR (20)  NULL,
    [Cellulare]     NVARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([CodiceFiscale] ASC)
);

CREATE TABLE [dbo].[Prenotazioni] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [ClienteID]         VARCHAR (16)    NOT NULL,
    [CameraID]          INT             NOT NULL,
    [DataPrenotazione]  DATE            DEFAULT (getdate()) NOT NULL,
    [NumeroProgressivo] INT             NOT NULL,
    [Anno]              INT             NOT NULL,
    [DataInizio]        DATE            NOT NULL,
    [DataFine]          DATE            NOT NULL,
    [Caparra]           DECIMAL (10, 2) NOT NULL,
    [TipoSoggiorno]     NVARCHAR (40)   NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([ClienteID]) REFERENCES [dbo].[Clienti] ([CodiceFiscale]),
    FOREIGN KEY ([CameraID]) REFERENCES [dbo].[Camere] ([Numero]),
    CHECK ([TipoSoggiorno]='pernottamento con prima colazione' OR [TipoSoggiorno]='pensione completa' OR [TipoSoggiorno]='mezza pensione')
);

CREATE TABLE [dbo].[Servizi] (
    [ID]      INT             IDENTITY (1, 1) NOT NULL,
    [Nome]    NVARCHAR (100)  NOT NULL,
    [Tariffa] DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[ServiziAggiuntivi] (
    [ID]             INT  IDENTITY (1, 1) NOT NULL,
    [PrenotazioneID] INT  NOT NULL,
    [ServizioID]     INT  NOT NULL,
    [Data]           DATE DEFAULT (getdate()) NOT NULL,
    [Quantita]       INT  DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([ServizioID]) REFERENCES [dbo].[Servizi] ([ID])
);

Ho popolato la cartella camere con 3 tipologie di camere: Singola, Doppia e Suite. In questa tabella c'è il numero della camera, la descrizione, il tipo, la tariffa giornaliera e la disponibilità. Queste sono tutte le camere disponibili dell'hotel per cui ho popolato questa tabella con 30 camere, 10 per tipo con i relativi dati.

La tabella servizi, anche questa già popolata, contiene tutti i servizi disponibili nell'hotel e relativo costo.

Le altre 3 tabelle gestiscono le prenotazioni, i clienti e i servizi aggiuntivi.

La prima voce sulla navbar è Prenotazione. Questa permette di inserire una nuova prenotazione. Devono essere inseriti tutti dati e alla fine i dati vengono salvati nel database nelle rispettive tabelle. Il campo input della camera viene gestito con un menù a tendina che recupera nel database tutte le camere disponibili e ne consente la scelta. Anche il tipo di soggiorno ha un menù per poter scegliere le tre tipologie previste (pernottamento con colazione, mezza pensione e pensione completa).

La seconda voce, Lista prenotazioni, visualizza tutte le prenotazioni nel database. A fianco di ogni prenotazione ci sono 2 bottoni, il primo consente di aggiungere un servizio e l'altro rimanda al checkout.

La vista per l'aggiunta del servizio presenta un form nel quale va inserito il tipo di servizio da inserire (questo recuperato dall'apposita tabella la cui scelta è possibile tramite menu a tendina), la data del servizio e la quantità. Premuto il bottone salva il tutto verrà salvato nel database con i giusti riferimenti.

Il bottone checkout produce una vista riepilogativa con tutti i dati della prenotazione, con tutti i servizi aggiuntivi e calcola il prezzo totale del soggiorno tenuto conto della caparra, del costo giornaliero e degli eventuali servizi aggiuntivi. In fondo ho messo un bottone STAMPA che consente di aprire di mandare in stampa (per mezzo di window.print()) il riepilogo del checkout. Ho previsto anche una classe css @media print che consente di stampare bene il riepilogo.

La terza voce sulla navbar consente di fare una chiamata asincrona ajax che per mezzo del codice fiscale recupera il dati di una prenotazione e se va a buon fine visualizza sotto i dati corrispettivi, aggiungendo a fianco due bottoni, Aggiungi Servizio e CheckOut.

L'ultima voce sulla navbar consente, sempre per mezzo di chiamata asincrona, di recuperare il conteggio delle prenotazioni in mezza pensione, pensione completa e pernottamento e mostrarli a video per mezzo di tabella.

In fine a destra della navbar c'è il bottone che consente il logout.

L'applicazione è perfettamente funzionante in tutte le sue parti e testabile.
