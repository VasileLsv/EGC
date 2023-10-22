1 ViewPoint este pozitia unei camere virtuale intrun spatiu 3D\
2 FPS se referă la numărul de cadre (imagini) afișate pe ecran într-o secundă de către o aplicație grafică  sau un joc care utilizează OpenGL pentru desenare\
3 OnUpdateFrame() este rulata atunci cand se actualizeaza cadrele,pe parcursul ciclului de randare\
4 Modul imediat de randare este o tehnica veche,ce se caracterizeaza prin  desenarea obiectelor grafice direct în cadrul buclei de randare \
5 3.x.x\
6 Metoda OnRenderFrame() este de obicei rulată în cadrul ciclului principal de randare. \
7 Metoda OnResize() trebuie să fie executată cel puțin o dată la începutul execuției aplicației pentru a configura corect fereastra sau contextul grafic, dimensiunea de vizualizare \
8 
fieldOfView: Acest parametru reprezintă câmpul vizual (FOV).Domeniul de valori pentru FOV este de obicei între 0 și π .\

aspectRatio: Acest parametru reprezintă raportul de aspect (aspect ratio).Raportul de aspect este raportul dintre lățime și înălțime. Domeniul de valori  poate fi calculat ca lățimea ecranului / înălțimea ecranului.\

zNear: Acest parametru reprezintă distanța la care se află "clipul apropiat" al frustrumului de vizualizare. Domeniul de valori pentru zNear trebuie să fie o valoare pozitivă.\

zFar: Acest parametru reprezintă distanța la care se află "clipul îndepărtat" al frustrumului de vizualizare.Domeniul de valori pentru zFar trebuie să fie o valoare pozitivă și mai mare decât zNear.\