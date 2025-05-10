# 📚 WebionLibraryAPI

API REST per la gestione di una biblioteca, sviluppata con ASP.NET Core 8.0 e PostgreSQL.

## ⚙️ Requisiti

- [Docker](https://www.docker.com/) installato
- File `.env` configurato (vedi sotto)

---

## 📁 Struttura del progetto

- `WebionLibraryAPI/` → progetto ASP.NET Core Web API
- `docker-compose.yml` → avvia sia l'applicazione che il database PostgreSQL
- `Migrations/` → cartella EF Core con le migrazioni già pronte

---

## 🧪 Funzionalità principali

- CRUD per libri, utenti e prenotazioni
- Rimozione automatica prenotazioni scadute (servizio in background)
- Swagger UI per test interattivi

---

## 🚀 Avvio rapido
Importante entrare nella cartella di lavoro:  
```bash
cd WebionLibraryAPI
```   

### 1. Crea il file `.env`

Copia il file di esempio:

```bash
cp .env.example .env
```
per farlo assicurati di essere nella corretta cartella

### 2. Avvio del progetto

Lancia l'applicazione e il database PostgreSQL con Docker Compose:

```bash
docker-compose up --build
```
in caso vengano apportate modifiche al progetto eseguire:  
⚠️⚠️ATTENZIONE⚠️⚠️  
Facendo ciò si perderanno tutti i dati presenti a db
```bash
docker-compose down -v
```  
per poi successivamente eseguire nuovamente il comando per compilare il tutto. (Mostrato qui sopra)  

---

## 🌐 Accesso alle API
Una volta avviato, visita:

🔗 http://localhost:8080/swagger — Interfaccia Swagger

---

## ✨ Autore
Barbieri Luka
