-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: boquester
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `author`
--

DROP TABLE IF EXISTS `author`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `author` (
  `author_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` char(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `last_name` char(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `description` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `birth_date` date DEFAULT NULL,
  `written_books` int(11) NOT NULL,
  PRIMARY KEY (`author_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `author`
--

LOCK TABLES `author` WRITE;
/*!40000 ALTER TABLE `author` DISABLE KEYS */;
INSERT INTO `author` VALUES (1,'Dan','Brown','Amerykański pisarz, autor powieści sensacyjnych. Jest absolwentem Phillips Exeter Academy, ekskluzywnej szkoły średniej z internatem, gdzie jego ojciec był nauczycielem matematyki, potem ukończył Amherst College (1986). Zanim rozpoczął karierę pisarską, zajmował się muzyką, wydał dwa nagrania, jednak nie okazały się one sukcesem. Po zaprzestaniu kariery muzycznej uczył języka angielskiego w swojej byłej szkole, Phillips Exeter. Obecnie mieszka w Nowej Anglii. Jego żona Blythe jest z zawodu ilustratorką, pasjonuje się historią sztuki i malarstwem, współpracuje z Brownem przy tworzeniu powieści.','1964-06-22',11),(2,'Remigiusz','Mróz','Polski pisarz, autor powieści kryminalnych oraz cyklu publicystycznego Kurs pisania. Ukończył z wyróżnieniem Akademię Leona Koźmińskiego w Warszawie, gdzie uzyskał stopień naukowy doktora nauk prawnych.','1987-01-15',49),(3,'Jane','Austen','Autorka powieści opisujących życie angielskiej klasy wyższej z początku XIX wieku. Mimo że sama wiodła stosunkowo odosobnione życie na prowincji w hrabstwie Hampshire, nie pozbawiło jej to zmysłu obserwacji i nie zubożyło dramaturgii jej utworów. Ich fabuła najczęściej dotyczy zamążpójścia i związanych z tym problemów społecznych (sama Austen nigdy nie wyszła za mąż). Reputację dobrej pisarki zyskała już za życia – jej powieści chwalił m.in. Walter Scott.','1775-12-16',4),(4,'Terry','Pratchett','Brytyjski pisarz fantasy i science fiction, najbardziej znany jako autor cyklu Świat Dysku. Inne jego dzieła to m.in. Trylogia Johnny’ego Maxwella i Trylogia Nomów. Współpracował także przy adaptacjach swojej twórczości na potrzeby sztuk teatralnych i gier komputerowych.','1948-04-28',5),(5,'Jakub','Żulczyk','Polski pisarz młodego pokolenia. Ukończył studia dziennikarskie na Uniwersytecie Jagiellońskim. Współpracownik pism „Lampa” i „Machina”, twórca rubryki „Tydzień kultury polskiej” w tygodniku „Wprost”. Autor powieści, z których dwie: „Instytut” i „Zmorojewo” wpisują się w konwencję horroru (przy czym ta ostatnia jest przede wszystkim powieścią przygodową dla młodszych czytelników). Fani alternatywnej muzyki rockowej z kolei wysoko cenią sobie „Radio Armageddon” (2008). Największy rozgłos przyniosła mu powieść „Ślepnąć od świateł”, na podstawie której powstał serial HBO. Autor nazywa siebie „pisarzem, niezależnym publicystą, recenzentem, felietonistą, blogerem, konsumentem śmieci i wzorowym odbiorcą kultury masowej”.','1983-08-12',2);
/*!40000 ALTER TABLE `author` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `book`
--

DROP TABLE IF EXISTS `book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book` (
  `book_id` int(11) NOT NULL AUTO_INCREMENT,
  `title` char(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `release_date` date NOT NULL,
  `publisher` int(11) DEFAULT NULL,
  `category` char(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `description` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `rate` float DEFAULT NULL,
  PRIMARY KEY (`book_id`),
  KEY `publisher` (`publisher`),
  CONSTRAINT `book_ibfk_1` FOREIGN KEY (`publisher`) REFERENCES `publisher` (`publisher_id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book`
--

LOCK TABLES `book` WRITE;
/*!40000 ALTER TABLE `book` DISABLE KEYS */;
INSERT INTO `book` VALUES (1,'Symfonia zwierząt','2020-09-02',2,'Dla dzieci','Niezwykła książka - do czytania i słuchania jednocześnie! Maestro Mysz, z batutą w ręku, zabiera czytelników w odwiedziny do różnych zwierząt. Spotyka między innymi gepardy, kangury, słonie i płetwale błękitne. Każde spotkanie niesie ważne przesłanie dla czytelnika.',2),(2,'Anioły i demony','2000-01-01',1,'kryminał,sensacja,thriller','Robert Langdon zostaje pilnie wezwany do położonego koło Genewy centrum badań jądrowych CERN. Jego zadanie - zidentyfikować zagadkowy wzór wypalony na ciele zamordowanego fizyka. Langdon ze zdumieniem stwierdza, że jest to symbol tajemnego bractwa iluminatów - potężnej, aczkolwiek nieistniejącej od czterystu lat organizacji walczącej z Kościołem, do której należały najświetniejsze umysły Europy, chociażby Galileusz. Jak się okazuje, iluminaci przetrwali w ukryciu do czasów współczesnych i planują straszliwą wendetę - wysadzenie Watykanu przy użyciu antymaterii wykradzionej z genewskiego laboratorium. Langdon i Vittoria Vetra, córka zamordowanego fizyka, mają zaledwie dobę, by odnaleźć utajnioną od XVI wieku siedzibę iluminatów i zapobiec niewyobrażalnej tragedii. Czy zdołają na czas rozszyfrować wskazówki zapisane w jedynym zachowanym w archiwach Świętego Miasta egzemplarzu legendarnego traktatu Galileusza? Jak zakończy się dramatyczny wyścig z czasem - po tajemnych kryptach i katakumbach, wyludnionych katedrach, tropem symboli iluminatów zakamuflowanych przed wiekami miejscach znanych każdemu mieszkańcowi Rzymu? Zagadka goni zagadkę, prowadząc do najbardziej nieoczekiwanego finału.',0),(3,'Kod Leonarda da Vinci','2003-03-01',1,'kryminał,sensacja,thriller','Jacques Saunicre, kustosz Luwru, zostaje zamordowany. Francuska policja o pomoc w śledztwie zwraca się do Roberta Langdona, specjalisty od symboli. Okazuje się, że na miejscu zbrodni znajduje się wiele śladów, które mogą pomóc w ustaleniu zabójcy, ale też stanowią klucz do jeszcze większej zagadki - niezwykłej tajemnicy sięgającej korzeniami początków chrześcijaństwa. Langdon podejrzewa, że zamordowany był członkiem Zakonu Syjonu, powstałego w 1099 roku tajnego stowarzyszenia strzegącego miejsca ukrycia bezcennej, zaginionej przed wiekami relikwii Kościoła - Świętego Graala. Do organizacji należeli m.in. Leonardo da Vinci i Isaac Newton. Kustosz poświęcił życie, by strzeżony przez zakon sekret nie ujrzał światła dziennego. Kluczowe elementy zagadki kryją się w najsłynniejszych obrazach mistrza Renesansu - Mona Lizie i Ostatniej wieczerzy. Czy ścigany przez policję i bezlitosnego zabójcę Langdon zdoła ujść pogoni i dotrzeć do szokującej prawdy? Jego jedynym sprzymierzeńcem jest piękna Sophie Neveu, agentka policji, specjalistka od tajnych kodów i szyfrów oraz wnuczka Saunicre\'a.',0),(4,'Zaginiony symbol','2009-01-01',1,'kryminał,sensacja,thriller','Robert Langdon, światowej sławy specjalista od symboli, zostaje niespodziewanie wezwany do Waszyngtonu, aby na prośbę swojego przyjaciela i mentora Petera Solomona, prominentnego członka loży masońskiej, wygłosić odczyt na Kapitolu. Kiedy dociera na miejsce, okazuje się, że zaproszenie było starannie przygotowaną pułapką. Na wieczór nie zaplanowano żadnego odczytu. Pośrodku historycznej Rotundy ktoś umieścił odciętą dłoń Petera z wytatuowanymi symbolami i masońskim pierścieniem. To mistyczne zaproszenie do zaginionego świata skrywającego tajemną wiedzę. Chcąc uratować porwanego przyjaciela, Langdon musi przyjąć zaproszenie i odnaleźć starożytny portal położony gdzieś na terenie miasta. Ma na to zaledwie kilkanaście godzin. W przeciwnym razie Solomon zginie. Rozpoczyna się szalony wyścig z czasem. Robert podąża tam, dokąd prowadzą go zaszyfrowane wskazówki: przesłanie ukryte w kwadratach magicznych, w Melancholii Albrechta Dürera, słynne rzeźbie Kryptos zdobiącej siedzibę CIA i na gigantycznym białym obelisku upamiętniającym prezydenturę Jerzego Waszyngtona. Do tajemnych komnat i świątyń znajdujących się pod jednym z najpotężniejszych miast świata. Do miejsc skrywających prastare sekrety loży masońskiej i tajemnice, których wielu wolałoby nie ujawniać.',0),(5,'Inferno','2013-10-09',1,'kryminał,sensacja,thriller','Światowej sławy specjalista od symboli, Robert Langdon budzi się na szpitalnym łóżku w zupełnie obcym miejscu. Nie pamięta, jak i dlaczego znalazł się w szpitalu. Nie potrafi też wyjaśnić, w jaki sposób wszedł w posiadanie tajemniczego przedmiotu, który znajduje we własnej marynarce. Czasu na rozmyślania nie ma niestety zbyt wiele. Ledwie na dobre odzyskuje przytomność, ktoś próbuje go zabić. W towarzystwie młodej lekarki Sienny Brooks Langdon opuszcza w pośpiechu szpital. Ścigany przez nieznanych wrogów przemierza uliczki Florencji, próbując odkryć powody niespodziewanego pościgu. Podąża śladem tajemniczych wskazówek ukrytych w słynnym poemacie Dantego Czy jego wiedza o tajemnych sekretach, które skrywa historyczna fasada miasta wystarczy, by umknąć nieznanym oprawcom? Czy zdoła rozszyfrować zagadkę i uratować świat przed śmiertelnym zagrożeniem?',0),(6,'Początek','2017-10-03',1,'kryminał,sensacja,thriller','Robert Langdon, profesor Uniwersytetu Harvarda, specjalista w dziedzinie ikonologii religijnej i symboli, przybywa do Muzeum Guggenheima w Bilbao, gdzie ma dojść do ujawnienia odkrycia, które na zawsze zmieni oblicze nauki. Gospodarzem wieczoru jest Edmond Kirsch, czterdziestoletni miliarder i futurysta, którego oszałamiające wynalazki i śmiałe przepowiednie zapewniły mu rozgłos na całym świecie. Kirsch, który dwadzieścia lat wcześniej był jednym z pierwszych studentów Langdona na Harvardzie, planuje ujawnić informację, która będzie stanowić odpowiedź na fundamentalne pytania dotyczące ludzkiej egzystencji. Gdy Langdon i kilkuset innych gości w osłupieniu ogląda oryginalną prezentację, wieczór zmienia się w chaos, a cenne odkrycie Kirscha może przepaść na zawsze. Chcąc stawić czoła nieuchronnemu zagrożeniu, Langdon musi uciekać z Bilbao. Towarzyszy mu Ambra Vidal, elegancka dyrektorka muzeum, która pomagała Kirschowi zorganizować wydarzenie. Razem udają się do Barcelony i podejmują niebezpieczną misję odnalezienia kryptograficznego hasła, które stanowi klucz do sekretu Kirscha',0),(7,'Cyfrowa twierdza','1998-02-22',1,'kryminał,sensacja,thriller','Narodowa Agencja Bezpieczeństwa (NSA) konstruuje superkomputer pozwalający złamać każdy szyfr metodą brutalnego ataku. Dzięki niemu amerykański wywiad może czytać komunikaty przesyłane przez terrorystów oraz szpiegów i w ten sposób udaremniać ich zamiary. Działalność agencji stara się pokrzyżować genialny japoński kryptolog Ensei Tankado, twórca niedającego się złamać algorytmu, nazwanego Cyfrową Twierdzą. Grożąc przekazaniem go do publicznego użytku, stawia niemożliwe do spełnienia żądania. Susan Fletcher, piękna matematyczka pracująca dla NSA, uczestniczy w dramatycznym wyścigu z czasem, by ocalić agencję, zdemaskować zdrajcę w jej szeregach i odkryć szczegóły planu, którego celem jest zniszczenie banku danych wywiadowczych USA. Stawką jest jej życie i życie mężczyzny, którego kocha.',0),(8,'Zwodniczy punkt','2001-01-01',1,'kryminał,sensacja,thriller','Najnowszy satelita NASA wykrywa niezwykły obiekt w lodowcach Arktyki, meteoryt ze śladami życia pozaziemskiego. Biały Dom przygotowuje się do poinformowania o odkryciu światowej opinii publicznej. Stanowiłoby ono sensację na miarę lądowania człowieka na Księżycu i zapewniło urzędującemu prezydentowi USA reelekcję. W celu zbadania meteorytu i stwierdzenia jego autentyczności na Arktykę udaje się grupa naukowców. Do grupy na osobiste polecenie prezydenta dołącza Rachel Sexton, analityk wywiadu, by przygotować opis znaleziska dla Białego Domu. Towarzyszy jej Michael Tolland, światowej klasy oceanograf. Wkrótce okazuje się, że rzekome odkrycie to precyzyjnie przygotowana mistyfikacja. Człowiek, który za nią stoi, zrobi wszystko, by prawda nie ujrzała światła dziennego. Rachel i Michael muszą uciekać, tropieni przez bezlitosnych komandosów. Próbują ostrzec prezydenta i ustalić, kto kryje się za misterną intrygą, zwodniczym punktem na kreślonej przez nich mapie spisku...',0),(9,'Lot 202','2020-05-20',3,'kryminał,sensacja,thriller','Zwyczajna, piątkowa noc w Nowej Hucie. Kamery monitoringu u zbiegu dwóch ulic rejestrują młodego chłopaka o drugiej piętnaście. Nie ma go na nagraniu z przecznicy dalej Sześć lat później, podkomisarz Agnieszka Oliwa odnajduje ciało chłopaka w Opolu. Wszystko wskazuje na to, że w wyjątkowo osobliwy sposób popełnił samobójstwo. Tymczasem z Okęcia startuje samolot z premierem na pokładzie. Zwykły lot do Toronto ma potrwać dziewięć godzin i trzydzieści pięć minut. Szybko okazuje się jednak, że najprawdopodobniej nigdy nie dotrze do celu rozpoczyna się wyścig z czasem, a jedyną poszlaką jest chłopak, który niegdyś zaginął na krakowskich ulicach.',0),(10,'Osiedle RZNiW','2020-07-15',2,'kryminał,sensacja,thriller','Wczesne lata dwutysięczne. Blokowisko na osiedlu RZNiW żyje w rytmie rapu, oddycha dymem z jointów i nie toleruje obcych. Na dwunastym piętrze jednego z bloków mieszka Deso - wychowujący się bez rodziców chłopak, który na co dzień musi zmagać się z życiem w skrajnej nędzy. Pewnej nocy otrzymuje esemesa z nieznanego numeru. Nadawca pisze: Boję się. Chyba ktoś za mną idzie. Deso po chwili oddzwania, ale w słuchawce słyszy jedynie trzaski. Nazajutrz okazuje się, że zaginęła dziewczyna z jego klasy. Chłopak nie wie, dlaczego próbowała skontaktować się akurat z nim, ale uznaje to za nieprzypadkowe i zaczyna szukać zaginionej.',0),(11,'Kasacja','2015-01-01',2,'kryminał,sensacja,thriller','Manipulacje, intrygi i bezwzględny, ale też fascynujący prawniczy świat Syn biznesmena zostaje oskarżony o zabicie dwóch osób. Sprawa wydaje się oczywista. Potencjalny winowajca spędza bowiem 10 dni zamknięty w swoim mieszkaniu z ciałami ofiar. Sprawę prowadzi Joanna Chyłka, pracująca dla bezwzględnej, warszawskiej korporacji. Nieprzebierająca w środkach prawniczka, która zrobi wszystko, by odnieść zwycięstwo w batalii sądowej. Pomaga jej młody, zafascynowany przełożoną, aplikant Kordian Oryński. Czy jednak wspólnie zdołają doprowadzić sprawę do szczęśliwego finału? Tymczasem ich klient zdaje się prowadzić własną grę, której reguły zna tylko on sam. Nie przyznaje się do winy, ale też nie zaprzecza, że jest mordercą.',0),(12,'Zaginięcie','2015-01-01',2,'kryminał,sensacja,thriller','Trzyletnia dziewczynka znika bez śladu z domku letniskowego bogatych rodziców. Alarm przez całą noc był wyłączony, a okna i drzwi zamknięte. Śledczy nie odnajdują żadnych poszlak świadczących o porwaniu i podejrzewają, że dziecko nie żyje. Doświadczona prawniczka, Joanna Chyłka, i jej początkujący podopieczny, Kordian Oryński, podejmują się obrony małżeństwa, któremu prokuratura stawia zarzut zabójstwa. Proces ma charakter poszlakowy, mimo to wszystko zdaje się wskazywać na winę rodziców- wszak gdy wyeliminuje się to, co niemożliwe, cokolwiek pozostanie,musi być prawdą...',0),(13,'Informacja zwrotna','2021-05-19',2,'kryminał,sensacja,thriller','Nazywam się Marcin Kania. Jestem alkoholikiem i zaraz zabiję człowieka. Syn Marcina Kani, żyjącego z tantiemów byłego muzyka, twórcy jednego z największych polskich hitów, pewnego dnia znika bez śladu. Jedyne, co po sobie pozostawia to zakrwawione prześcieradła. Kania wie, że poprzedniego wieczoru widział się z synem. Jednak prawie nic z tego spotkania nie pamięta. Zapił. Kania, alkoholik leczący się z choroby w ośrodku ,,Jutro\", wyrusza w szaleńczą podróż w poszukiwaniu syna. Ta odyseja po mieście, w którym każde z miejsc ma swoja brudną tajemnicę, popchnie go w najmroczniejsze rejony ludzkiego psyche, naprowadzi na trop największej w polskich dziejach afery reprywatyzacyjnej oraz skonfrontuje ze złem, które wyrządził swojej rodzinie.Klucz do odkupienia i odnalezienia syna tkwi w jego wyniszczonym przez alkohol umyśle. Musi sobie tylko przypomnieć. Jaka będzie informacja zwrotna? ',0),(14,'Ślepnąc od świateł','2014-10-22',2,'kryminał,sensacja,thriller','Zawsze chodzi wyłącznie o pieniądze. O nic innego. Ktoś może powiedzieć ci, że to niska pobudka. To nieprawda - oświadcza bohater powieści Jakuba Żulczyka. Ten młody człowiek przyjechał z Olsztyna do Warszawy, gdzie prawie skończył ASP. By uniknąć powielania egzystencjalnych schematów swoich rówieśników – przyszłych meneli, ludzi mogących w najlepszym razie otrzeć się o warstwy klasy średniej, niepoprawnych idealistów – dokonał życiowego wyboru według własnych upodobań: Zawsze lubiłem ważyć i liczyć. Waży więc narkotyki i liczy pieniądze jako handlarz kokainy. W dzień śpi, w nocy odbywa samochodowy rajd po mieście, rozprowadzając towar, ale także bezwzględnie i brutalnie ściągając od dłużników pieniądze, przy pomocy odpowiednich ludzi. Jakub Żulczyk w poruszający sposób ukazuje współczesną rzeczywistość, zdeformowaną do tego stopnia, że handlarz narkotyków staje się równie niezbędny jak strażak czy lekarz; jest nocnym dostawcą paliwa dla tych, którzy chcą – albo muszą – utrzymać się na powierzchni.',0),(15,'Perswazje','1971-01-01',4,'klasyka','Trzykrotnie zekranizowana powieść obyczajowa znakomitej angielskiej pisarki Jane Austen, po raz pierwszy wydana już po jej śmierci. Błyskotliwe połączenie portretu szlachty angielskiej początku XIX wieku oraz intrygującego romansu. Pomimo urody, dobroci i niezwykłej delikatności Anna Elliot wciąż jest samotna, żyje „przy rodzinie”. Jako młoda dziewczyna, pod wpływem perswazji i dobrych rad, zerwała zaręczyny z kapitanem marynarki Fryderykiem Wentworthem. Ten, zraniony i pełen żalu, wyruszył na morze. Przez wiele lat nie mieli ze sobą żadnego kontaktu… Ale czy można całkowicie wyrzucić z pamięci wielką miłość? I czy czas zmienia ludzi tak, że nic już do siebie nie czują?',0),(16,'Emma','1994-01-01',4,'klasyka','Błyskotliwa komedia omyłek, której przedmiotem jest gra pozorów i iluzje, jakich dostarcza nam w nadmiarze nasz egoizm i zadufanie. W samym zaś środku intrygi stoi niezwykła bohaterka, pełna życia i wigoru, urocza, nieznośna i apodyktyczna Emma. Emma Woodhouse mieszka z ojcem na angielskiej prowincji. Chociaż sama nie zamierza wyjść za mąż, próbuje swoich sił jako swatka. W sprawach serca jednak nie wszystko da się przewidzieć. Może z konwencjonalnych gestów, grzeczności przewidzianych etykietą, ukradkowych spojrzeń zostaną odczytane prawdziwe intencje? Jak to w komedii omyłek bywa...',0),(17,'Duma i uprzedzenie','1813-01-28',4,'klasyka','Najgłośniejsza powieść Jane Austen, na podstawie której zrealizowano równie głośny film. Nawiązuje do niej Helen Fielding w bestsellerowym Dzienniku Bridget Jones. Niepozbawiona ironii i humoru kostiumowa opowieść o zamążpójściu.Rzecz dzieje się na angielskiej prowincji na przełomie XVIII i XIX wieku. Niezbyt zamożni państwo Bennetowie mają nie lada kłopot – nadeszła pora, by wydać za mąż ich pięć dorosłych córek. Sęk w tym, że niełatwo jest znaleźć odpowiedniego męża na prowincji. Pojawia się jednak iskierka nadziei, bo oto posiadłość po sąsiedzku postanawia dzierżawić pewien młody człowiek, przystojny i bogaty... ',0),(18,'Rozważna i romantyczna','1977-01-01',4,'klasyka','Po śmierci męża pani Dashwood wraz z dziećmi opuściła ukochany dom i zamieszkała w posiadłości Barton. Dwie z jej córek - panny na wydaniu - choć różne pod względem charakterów, tak samo szukają szczęścia i miłości. Uczuciowa, impulsywna Marianna marzy o mężczyźnie szarmanckim, wrażliwym, lubiącym te same lektury co ona. Łagodna i rozważna Eleonora odda serce jedynie człowiekowi spokojnemu i odpowiedzialnemu. Niestety świat, którym - zamiast prawdziwych uczuć - rządzi pozycja społeczna i pieniądz, może boleśnie rozczarować te pełne uroku, ufne kobiety…',0),(19,'Kolor magii','1983-01-01',6,'fantastyka, fantasy, science fiction','To pierwsza część słynnego wieloksięgu rozgrywającego się na płaskiej ziemi śmieszna, mądra i cudownie zadowalająca jak wszystkie książki Pratchetta. W odległym, trochę już zużytym układzie współrzędnych, na płaszczyźnie astralnej, która nigdy nie była szczególnie płaska, skłębiona mgiełka gwiazd rozstępuje się z wolna... Spójrzcie...',0),(20,'Blask fantastyczny','1984-01-01',6,'fantastyka, fantasy, science fiction','Tylko jedna osoba może ocalić Świat Dysku, który sunie ku nieuniknionej z pozoru kolizji ze złowróżbną czerwoną gwiazdą. Na nieszczęście, osobą tą jest mało uzdolniony i tchórzliwy mag o imieniu Ricewind, którego po raz ostatni widziano, jak spadł poza krawędź świata... Rincewind zostaje magicznie ściągnięty z Kosmosu, by stać się obiektem polowania wszystkich ośmiu Obrządków Magicznych, próbujących odzyskać ukryte w jego umyśle Zaklęcie. W towarzystwie Dwukwiata z Bagażem i Cohena - największego i najsłynniejszego z bohaterów Dysku (choć ostatnio trochę bez formy) - po licznych przygodach powraca do Ankh Morpork, by uczestniczyć w jednym z kluczowych wydarzeń historii i kosmologii równocześnie.',0),(21,'Równoumagicznienie','1985-01-01',6,'fantastyka, fantasy, science fiction','Jest to opowieść o tym, czym jest magia i dokąd zmierza, a co ważniejsze, skąd przychodzi i po co. Przedstawiona historia nie pretenduje do odpowiedzi na wszystkie te pytania, może jednak pomóc w wyjaśnieniu, dlaczego Gandalf nigdy się nie ożenił i dlaczego Merlin był mężczyzną. Jest to również opowieść o seksie, choć nie w sensie atletyczno-gimnastycznym, czy też w sensie policz wszystkie nogi i podziel przez dwa. Chyba że postacie całkowicie wyrwą się spod kontroli autora. I to jest możliwe.',0),(22,'Mort','1986-01-01',6,'fantastyka, fantasy, science fiction','Czasem nawet śmierć potrzebuje wakacji - a na Świecie Dysku, jedynej Płaskiej Ziemi we wszystkich wszechświatach, kościsty strażnik klepsydry życia uświadamia sobie, że tylko jedno może dać mu chwilę wytchnienia: terminator. Wybiera więc sobie Morta - chłopca gorliwie pragnącego zdobyć wiedzę, której stanowczo posiadać nie powinien. Wprawdzie Mort szybko opanowuje tajniki przechodzenia przez ściany, jednak nauka obiektywizmu to całkiem inna sprawa. Zwłaszcza kiedy życie, po które został wysłany, należy do pięknej, młodej księżniczki. W związku ze zmianą biegu losu rzeczywistość chwieje się w posadach. A że Śmierć wyruszył w podróż, by poznać rozkosze śmiertelnych, to właśnie Mort, z pomocą niezbyt kompletnego maga imieniem Cutwell oraz adoptowanej i pełnej entuzjazmu córki Śmierci, musi naprawić przyszły tor historii - zanim Dysk się przekręci...',0),(23,'Czarodzicielstwo','1989-01-01',6,'fantastyka, fantasy, science fiction','Narodził się Czarodziciel czarownik tak potężny, że w porównaniu z jego mocą wszelka magia jest tylko dziecinną zabawką. Samo jego istnienie doprowadza świat Dysku, który oczywiście jest płaski i płynie w przestrzeni na grzbiecie gigantycznego żółwia, na krawędź totalnej wojny taumaturgicznej. To niedobrze. Na jego drodze stoi jedynie Rincewind, nieudany mag, który chce ocalić świat, a przynajmniej tę część, która zawiera jego osobę. W przygodzie uczestniczą nowe postaci: Conena, barbarzyńska fryzjerka, Nijel Niszczyciel (którego matka wciąż zmusza do noszenia wełnianej bielizny) i być może pierwszy dżin-yuppie, który zajmuje się lampami jako potencjalnie obiecującym rynkiem. Los prowadzi ich na Wschód, czy też w stronę Osi czy jakoś tak.',0);
/*!40000 ALTER TABLE `book` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `booksauthors`
--

DROP TABLE IF EXISTS `booksauthors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `booksauthors` (
  `books_authors_id` int(11) NOT NULL AUTO_INCREMENT,
  `book_id` int(11) NOT NULL,
  `author_id` int(11) NOT NULL,
  PRIMARY KEY (`books_authors_id`),
  KEY `book_id` (`book_id`),
  KEY `author_id` (`author_id`),
  CONSTRAINT `booksauthors_ibfk_1` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`),
  CONSTRAINT `booksauthors_ibfk_2` FOREIGN KEY (`author_id`) REFERENCES `author` (`author_id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booksauthors`
--

LOCK TABLES `booksauthors` WRITE;
/*!40000 ALTER TABLE `booksauthors` DISABLE KEYS */;
INSERT INTO `booksauthors` VALUES (1,1,1),(2,2,1),(3,3,1),(4,4,1),(5,5,1),(6,6,1),(7,7,1),(8,8,1),(9,9,2),(10,10,2),(11,11,2),(12,12,2),(13,13,5),(14,14,5),(15,15,3),(16,16,3),(17,17,3),(18,18,3),(19,19,4),(20,20,4),(21,21,4),(22,22,4),(23,23,4);
/*!40000 ALTER TABLE `booksauthors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `booksusers`
--

DROP TABLE IF EXISTS `booksusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `booksusers` (
  `books_users_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `book_id` int(11) NOT NULL,
  `is_read` tinyint(1) NOT NULL,
  `want_to_read` tinyint(1) DEFAULT NULL,
  `rate` enum('1','2','3','4','5','6','7','8','9','10') CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`books_users_id`),
  KEY `user_id` (`user_id`),
  KEY `book_id` (`book_id`),
  CONSTRAINT `booksusers_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  CONSTRAINT `booksusers_ibfk_2` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booksusers`
--

LOCK TABLES `booksusers` WRITE;
/*!40000 ALTER TABLE `booksusers` DISABLE KEYS */;
INSERT INTO `booksusers` VALUES (1,2,3,1,0,'8'),(2,2,6,1,0,'6'),(3,1,7,0,1,''),(4,2,11,1,0,'8'),(5,1,2,0,1,NULL),(6,4,20,1,0,'8'),(7,4,19,1,0,'9'),(8,4,21,1,0,'9'),(9,4,22,1,0,'8'),(10,4,23,1,0,'7'),(11,3,12,0,1,NULL),(12,3,16,0,1,NULL),(13,3,14,1,0,'5'),(14,3,18,1,0,'10');
/*!40000 ALTER TABLE `booksusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `publisher`
--

DROP TABLE IF EXISTS `publisher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `publisher` (
  `publisher_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` char(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`publisher_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `publisher`
--

LOCK TABLES `publisher` WRITE;
/*!40000 ALTER TABLE `publisher` DISABLE KEYS */;
INSERT INTO `publisher` VALUES (1,'Sonia Draga'),(2,'Czwarta Strona'),(3,'Debit'),(4,'Filia'),(5,'Tandem'),(6,'Prószyński i S-ka');
/*!40000 ALTER TABLE `publisher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `login` char(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `passwd` char(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `join_date` date NOT NULL,
  `read_books` int(11) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'mol_ksiazkowy','2c3a37566aaa4228b504a10da7a433298b21c84e1152a68c0fd6d5a47158f','2021-06-21',0),(2,'Konstantyna89','f9bd7d1e55c83e3a7329a5a285606e49823487e035bc973d79084f74ef2fa36','2021-07-03',3),(3,'Zaczytana','bc218ab2c34cabfeea284028df3e8a247d644f71f3bea0f3fb896357a4cd7446','2020-03-04',0),(4,'Agatka','9b971780f63d4d90eb7475ed1e365ba78559f7b2fd557f1d2650f92e10d7f8e1','2021-01-01',0),(5,'Kuba_2137','c4bff4a2fc27b236138b367c6297c736f96718a82851830121e3a4988db4c84','2021-02-15',0),(6,'root','9b971780f63d4d90eb7475ed1e365ba78559f7b2fd557f1d2650f92e10d7f8e1','2021-09-03',0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-09-04  0:16:57
