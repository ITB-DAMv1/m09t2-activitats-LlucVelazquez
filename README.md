# T2. Activitats

## Exercici 1.

La llibreria System.Diagnostics proporciona classes que permeten interactuar amb processos del sistema, registres desdeveniments i comptadors de rendiment.

- BooleanSwitch: Proporciona un commutador d'activat/desactivat senzill que controla els resultats de depuració i traça.

- Debug: Proporciona un conjunt de mètodes i propietats que ajuden a depurar el codi.

- MonitoringDescriptionAttribute: Especifica una descripció per a una propietat o esdeveniment.

- Process: Proporciona accés a processos locals i remots i us permet iniciar i aturar els processos del sistema local.

- Stopwatch: Proporciona un conjunt de mètodes i propietats que podeu utilitzar per mesurar el temps transcorregut amb precisió.

## Exercici 4.



| **Aspecte** | **Thread** | **Task** |
| :-- | :-- | :-- |
| **Nivell d'abstracció** | Baix nivell (control directe del sistema operatiu) | Alt nivell (part de la TPL - Task Parallel Library) |
| **Creació** | `new Thread(ThreadStart)` | `Task.Run(Action)` o `Task.Factory.StartNew(Action)` |
| **Mètodes destacats** | - `Start()`<br>- `Join()`<br>- `Sleep(int)`<br>- `Abort()` (obsolet)<br>- `Suspend()`/`Resume()` (obsolets) | - `Wait()`<br>- `WaitAll()`/`WaitAny()`<br>- `ContinueWith(Action)`<br>- `RunSynchronously()` |
| **Gestió de recursos** | Consumeix més recursos (1 MB per stack) | Optimitza recursos amb thread pool (reutilització de fils) |
| **Retorn de resultats** | No suportat directament (cal usar variables compartides) | Suportat via `Task&lt;TResult&gt;` i `Result` |
| **Cancel·lació** | `Abort()` (insegur) | `CancellationToken` amb `ThrowIfCancellationRequested()` |
| **Excepcions** | No capturades automàticament (cal gestionar manualment) | Agrupades en `AggregateException` (accessible via `Exception` property) |
| **Sincronització** | Requereix `lock`, `Monitor`, o `Mutex` | Integració amb `async`/`await` per codi no-bloquejant |
| **Escalabilitat** | Limitada per sobrecàrrega de context-switching | Millor escalabilitat gràcies al thread pool |
| **Casos d'ús** | - Control precís del fil<br>- Operacions de llarga durada<br>- APIs heredades | - Operacions asíncrones<br>- Paral·lelisme de dades<br>- Operacions I/O |


---

- Start: Inicia l'execució del fil.
- Join:  Bloqueja el fil actual fins que acabi el fil especificat.
- Sleep: Suspèn el fil actual durant el temps especificat.
- CurrentThread: Retorna el fil actualment en execució.
- IsBackground:  Determina si el fil s'executa en segon pla.

[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/LXcrfC_Y)
