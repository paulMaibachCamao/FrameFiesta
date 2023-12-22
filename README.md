[DummyDaten.json](https://github.com/paulMaibachCamao/FrameFiesta/files/13752717/DummyDaten.json)[FrameFiesta.postman_collection.json](https://github.com/paulMaibachCamao/FrameFiesta/files/13752703/FrameFiesta.postman_collection.json)# Einleitung
Das Backend zum BT-S Schulprojekt im 3. Lehrjahr - FrameFiesta

[Frontend Repo](https://github.com/JannikKrusch/framefiesta)

# Einrichtung
Das Backend ist nach dem Klonen des Repository ausführbar, jedoch erfüllt es erst mit der Datenbank die vollständige Funktion

## Kurzanleitung
1. Repository klonen
2. ```bash
   FrameFiesta.Api
   └───appsettings.json
   ```
    MongoDBCompass installieren und `ConnectionString` anpassen
4. Postman installieren
5. Dummydaten mit Postman erstellen

## Anleitung
Wir benutzen MongoDB als Datenbank. Mit [MongoDBCompass](https://www.mongodb.com/try/download/compass) bietet MongoDB eine grafische Oberfläche, um mit dieser zur interagiern.
Die Standardeinstellungen zum Connecten benutzen, die `URL` im Backend in der `appsettings.json` beim `ConnectionString` einfügen.

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/97b4d41d-dec6-4ec0-b969-a3470ec312d3)

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/5a8ec395-0490-4dca-97bb-f70c783fd0db)

Falls nötig, muss nun [Postman](https://www.postman.com/downloads/) installiert werden.
Nun muss man die `Postman Collection` und die `Dummydaten` Dateien herunterladen.

[Uploading FrameFie{
	"info": {
		"_postman_id": "d21e9637-a2e9-4a62-b3ab-87c723e6fd21",
		"name": "FrameFiesta",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json",
		"_exporter_id": "21236378"
	},
	"item": [
		{
			"name": "Register",
			"event": [
				{
					"listen": "prerequest",
					"script": {
						"exec": [
							"let requestBodyRegister = {\r",
							"    \"Name\": data.User.Name,\r",
							"    \"Email\": data.User.Email,\r",
							"    \"Password\": data.User.Password\r",
							"};\r",
							"\r",
							"pm.variables.set(\"requestBodyRegister\", JSON.stringify(requestBodyRegister));"
						],
						"type": "text/javascript"
					}
				},
				{
					"listen": "test",
					"script": {
						"exec": [
							"pm.test(\"Statuscode is 200\", function () {\r",
							"    pm.response.to.have.status(200);\r",
							"});\r",
							"\r",
							"pm.test(\"Getting correct user data back\", function () {\r",
							"    var responseData = pm.response.json();\r",
							"    pm.expect(responseData).to.have.property('name');\r",
							"    pm.expect(responseData).to.have.property('email');\r",
							"\r",
							"    pm.expect(responseData.name).to.eql(data.User.Name);\r",
							"    pm.expect(responseData.email).to.eql(data.User.Email);\r",
							"});"
						],
						"type": "text/javascript"
					}
				}
			],
			"request": {
				"method": "POST",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{{requestBodyRegister}}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:44302/api/FrameFiesta/register",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44302",
					"path": [
						"api",
						"FrameFiesta",
						"register"
					]
				}
			},
			"response": []
		},
		{
			"name": "User",
			"event": [
				{
					"listen": "prerequest",
					"script": {
						"exec": [
							"let requestBodyDelete = {\r",
							"    \"UserIdentification\": data.User.Name,\r",
							"    \"Password\": data.User.Password\r",
							"};\r",
							"\r",
							"pm.variables.set(\"requestBodyDelete\", JSON.stringify(requestBodyDelete));"
						],
						"type": "text/javascript"
					}
				},
				{
					"listen": "test",
					"script": {
						"exec": [
							"pm.test(\"Statuscode is 200\", function () {\r",
							"    pm.response.to.have.status(200);\r",
							"});\r",
							"\r",
							"pm.test(\"Getting true back\", function () {\r",
							"    var responseData = pm.response.json();\r",
							"    pm.expect(responseData).to.be.true;\r",
							"});"
						],
						"type": "text/javascript"
					}
				}
			],
			"request": {
				"method": "DELETE",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{{requestBodyDelete}}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:44302/api/FrameFiesta/user",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44302",
					"path": [
						"api",
						"FrameFiesta",
						"user"
					]
				}
			},
			"response": []
		},
		{
			"name": "Register 2",
			"event": [
				{
					"listen": "prerequest",
					"script": {
						"exec": [
							"let requestBodyRegister = {\r",
							"    \"Name\": data.User.Name,\r",
							"    \"Email\": data.User.Email,\r",
							"    \"Password\": data.User.Password\r",
							"};\r",
							"\r",
							"pm.variables.set(\"requestBodyRegister\", JSON.stringify(requestBodyRegister));"
						],
						"type": "text/javascript"
					}
				},
				{
					"listen": "test",
					"script": {
						"exec": [
							"pm.test(\"Statuscode is 200\", function () {\r",
							"    pm.response.to.have.status(200);\r",
							"});\r",
							"\r",
							"pm.test(\"Getting correct user data back\", function () {\r",
							"    var responseData = pm.response.json();\r",
							"    pm.expect(responseData).to.have.property('name');\r",
							"    pm.expect(responseData).to.have.property('email');\r",
							"\r",
							"    pm.expect(responseData.name).to.eql(data.User.Name);\r",
							"    pm.expect(responseData.email).to.eql(data.User.Email);\r",
							"});"
						],
						"type": "text/javascript"
					}
				}
			],
			"request": {
				"method": "POST",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{{requestBodyRegister}}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:44302/api/FrameFiesta/register",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44302",
					"path": [
						"api",
						"FrameFiesta",
						"register"
					]
				}
			},
			"response": []
		},
		{
			"name": "Blogpost",
			"event": [
				{
					"listen": "prerequest",
					"script": {
						"exec": [
							"let type = data.RelatedMotionPicture.type;\r",
							"let requestBody;\r",
							"\r",
							"if (type === \"Film\") {\r",
							"    requestBody = {\r",
							"        \"Id\": data.Id,\r",
							"        \"Date\": data.Date,\r",
							"        \"Description\": data.Description,\r",
							"        \"Review\": data.Review,\r",
							"        \"Comments\": data.Comments,\r",
							"        \"RelatedMotionPicture\": {\r",
							"            \"Title\": data.RelatedMotionPicture.Title,\r",
							"            \"Director\": data.RelatedMotionPicture.Director,\r",
							"            \"Country\": data.RelatedMotionPicture.Country,\r",
							"            \"Actors\": data.RelatedMotionPicture.Actors,\r",
							"            \"Rating\": data.RelatedMotionPicture.Rating,\r",
							"            \"Image\": data.RelatedMotionPicture.Image,\r",
							"            \"Genres\": data.RelatedMotionPicture.Genres,\r",
							"            \"InitialRelease\": data.RelatedMotionPicture.InitialRelease,\r",
							"            \"Type\": type,\r",
							"            \"RunTime\": data.RelatedMotionPicture.RunTime,\r",
							"            \"AgeRating\": data.RelatedMotionPicture.AgeRating,\r",
							"            \"Budget\": data.RelatedMotionPicture.Budget\r",
							"        }\r",
							"    };\r",
							"} else if (type === \"Series\") {\r",
							"    requestBody = {\r",
							"        \"Id\": data.Id,\r",
							"        \"Date\": data.Date,\r",
							"        \"Description\": data.Description,\r",
							"        \"Review\": data.Review,\r",
							"        \"Comments\": data.Comments,\r",
							"        \"RelatedMotionPicture\": {\r",
							"            \"Title\": data.RelatedMotionPicture.Title,\r",
							"            \"Director\": data.RelatedMotionPicture.Director,\r",
							"            \"Country\": data.RelatedMotionPicture.Country,\r",
							"            \"Actors\": data.RelatedMotionPicture.Actors,\r",
							"            \"Rating\": data.RelatedMotionPicture.Rating,\r",
							"            \"Image\": data.RelatedMotionPicture.Image,\r",
							"            \"Genres\": data.RelatedMotionPicture.Genres,\r",
							"            \"InitialRelease\": data.RelatedMotionPicture.InitialRelease,\r",
							"            \"Type\": type,\r",
							"            \"Seasons\": data.RelatedMotionPicture.Seasons,\r",
							"            \"Episodes\": data.RelatedMotionPicture.Episodes,\r",
							"            \"AgeRating\": data.RelatedMotionPicture.AgeRating,\r",
							"            \"Budget\": data.RelatedMotionPicture.Budget\r",
							"        }\r",
							"    };\r",
							"}\r",
							"\r",
							"pm.variables.set(\"requestBody\", JSON.stringify(requestBody));"
						],
						"type": "text/javascript"
					}
				},
				{
					"listen": "test",
					"script": {
						"exec": [
							"pm.test(\"Statuscode is 201\", function () {\r",
							"    pm.response.to.have.status(201);\r",
							"});"
						],
						"type": "text/javascript"
					}
				}
			],
			"request": {
				"method": "PUT",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{{requestBody}}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:44302/api/FrameFiesta/blogpost",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44302",
					"path": [
						"api",
						"FrameFiesta",
						"blogpost"
					]
				}
			},
			"response": []
		},
		{
			"name": "Blogposts",
			"event": [
				{
					"listen": "test",
					"script": {
						"exec": [
							"pm.test(\"Statuscode is 200\", function () {\r",
							"    pm.response.to.have.status(200);\r",
							"});\r",
							"\r",
							"var responseData = pm.response.json();\r",
							"\r",
							"pm.test(\"Response is an array\", function () {\r",
							"    pm.expect(Array.isArray(responseData)).to.be.true;\r",
							"});\r",
							"\r",
							"pm.test(\"Response array is not empty\", function () {\r",
							"    pm.expect(responseData.length).to.be.above(0);\r",
							"});\r",
							"var blogId = responseData[0].id;\r",
							"console.log(blogId);\r",
							"pm.environment.set(\"BlogId\", blogId);"
						],
						"type": "text/javascript"
					}
				}
			],
			"request": {
				"method": "GET",
				"header": [],
				"url": {
					"raw": "https://localhost:44302/api/FrameFiesta/blogposts",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44302",
					"path": [
						"api",
						"FrameFiesta",
						"blogposts"
					]
				}
			},
			"response": []
		},
		{
			"name": "Comment",
			"event": [
				{
					"listen": "prerequest",
					"script": {
						"exec": [
							"let requestBodyAddComment = {\r",
							"    \"UserIdentification\": data.User.Name,\r",
							"    \"Password\": data.User.Password,\r",
							"    \"Comment\": data.Comment\r",
							"};\r",
							"\r",
							"pm.variables.set(\"requestBodyAddComment\", JSON.stringify(requestBodyAddComment));"
						],
						"type": "text/javascript"
					}
				},
				{
					"listen": "test",
					"script": {
						"exec": [
							"pm.test(\"Statuscode is 200\", function () {\r",
							"    pm.response.to.have.status(200);\r",
							"});\r",
							"\r",
							"var responseData = pm.response.json();\r",
							"\r",
							"pm.test(\"Getting correct data back\", function() {\r",
							"    pm.expect(responseData.text).to.be.eql(data.Comment);\r",
							"    pm.expect(responseData.name).to.be.eql(data.User.Name);\r",
							"})"
						],
						"type": "text/javascript"
					}
				}
			],
			"request": {
				"method": "PUT",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{{requestBodyAddComment}}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:44302/api/FrameFiesta/comment?blogId={{BlogId}}",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44302",
					"path": [
						"api",
						"FrameFiesta",
						"comment"
					],
					"query": [
						{
							"key": "blogId",
							"value": "{{BlogId}}"
						}
					]
				}
			},
			"response": []
		},
		{
			"name": "Login",
			"event": [
				{
					"listen": "prerequest",
					"script": {
						"exec": [
							"let requestBodyLogin = {\r",
							"    \"UserIdentification\": data.User.Name,\r",
							"    \"Password\": data.User.Password\r",
							"};\r",
							"\r",
							"pm.variables.set(\"requestBodyLogin\", JSON.stringify(requestBodyLogin));"
						],
						"type": "text/javascript"
					}
				},
				{
					"listen": "test",
					"script": {
						"exec": [
							"pm.test(\"Statuscode is 200\", function () {\r",
							"    pm.response.to.have.status(200);\r",
							"});\r",
							"\r",
							"var responseData = pm.response.json();\r",
							"\r",
							"pm.environment.set(\"CommentId\", responseData.comments[0].id);"
						],
						"type": "text/javascript"
					}
				}
			],
			"request": {
				"method": "POST",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{{requestBodyLogin}}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:44302/api/FrameFiesta/login",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44302",
					"path": [
						"api",
						"FrameFiesta",
						"login"
					]
				}
			},
			"response": []
		},
		{
			"name": "Comment",
			"event": [
				{
					"listen": "prerequest",
					"script": {
						"exec": [
							"let requestBodyDelete = {\r",
							"    \"UserIdentification\": data.User.Name,\r",
							"    \"Password\": data.User.Password\r",
							"};\r",
							"\r",
							"pm.variables.set(\"requestBodyDelete\", JSON.stringify(requestBodyDelete));"
						],
						"type": "text/javascript"
					}
				},
				{
					"listen": "test",
					"script": {
						"exec": [
							"pm.test(\"Statuscode is 200\", function () {\r",
							"    pm.response.to.have.status(200);\r",
							"});\r",
							"\r",
							"pm.test(\"Getting true back\", function () {\r",
							"    var responseData = pm.response.json();\r",
							"    pm.expect(responseData).to.be.true;\r",
							"});"
						],
						"type": "text/javascript"
					}
				}
			],
			"request": {
				"method": "DELETE",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{{requestBodyDelete}}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:44302/api/FrameFiesta/comment?blogId={{BlogId}}&commentId={{CommentId}}",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "44302",
					"path": [
						"api",
						"FrameFiesta",
						"comment"
					],
					"query": [
						{
							"key": "blogId",
							"value": "{{BlogId}}"
						},
						{
							"key": "commentId",
							"value": "{{CommentId}}"
						}
					]
				}
			},
			"response": []
		}
	]
}sta.postman_collection.json…]()

[Uploading DummyDat[
    {
        "Id": "BlogId0",
        "Date": "2023-01-01T00:00:00",
        "Description": "'The Shining' ist ein ikonischer Horrorfilm, der auf dem gleichnamigen Roman von Stephen King basiert und von Stanley Kubrick meisterhaft inszeniert wurde. Die Handlung dreht sich um Jack Torrance, der mit seiner Familie als Hausmeister in das abgelegene Overlook Hotel zieht. Doch das Hotel birgt dunkle Geheimnisse, die Jacks Verstand und seine Familie bedrohen. Jack Nicholson liefert eine beeindruckende Performance als Jack Torrance, der nach und nach dem Wahnsinn verf\u00e4llt. Shelley Duvall \u00fcberzeugt ebenfalls in ihrer Rolle als seine Ehefrau Wendy, die inmitten des Schreckens um das \u00dcberleben ihrer Familie k\u00e4mpft. Stanley Kubrick schafft eine unheimliche Atmosph\u00e4re mit meisterhafter Kameraarbeit und subtilen visuellen Effekten. Der Film erforscht Themen wie Isolation, Wahnsinn und die dunklen Abgr\u00fcnde der menschlichen Psyche und bietet Raum f\u00fcr verschiedene Interpretationen. 'The Shining' ist ein zeitloser Klassiker des Horrorgenres, der seine Zuschauer mit seiner Intensit\u00e4t und seinem unheimlichen Charme fesselt. Ein Film, der immer wieder angesehen werden kann und eine unvergleichliche Erfahrung bietet.",
        "Review": "'The Shining' ist zweifellos ein Meisterwerk des Horrorfilms und ein unvergessliches St\u00fcck des Kinos. Dieser Film, basierend auf dem gleichnamigen Roman von Stephen King und unter der Regie von Stanley Kubrick, hat sich als zeitloser Klassiker etabliert, der Generationen von Zuschauern in seinen Bann gezogen hat. Die Geschichte folgt Jack Torrance, gespielt von Jack Nicholson, der als Hausmeister mit seiner Familie in das abgelegene Overlook Hotel einzieht, um es \u00fcber den Winter zu betreuen. Doch das Hotel, das in der Nebensaison menschenleer ist, birgt dunkle Geheimnisse und eine unheimliche Pr\u00e4senz, die Jacks Verstand und seine Familie bedrohen. Die Leistung von Jack Nicholson in dieser Rolle ist legend\u00e4r. Seine Darstellung eines Mannes, der dem Wahnsinn verf\u00e4llt, ist absolut faszinierend und verst\u00f6rend zugleich. Shelley Duvall als seine Ehefrau Wendy liefert ebenfalls eine beeindruckende Performance, die die \u00c4ngste und den Schrecken ihrer Figur glaubhaft vermittelt. Stanley Kubrick inszeniert den Film meisterhaft. Die Kameraarbeit, die Musik und die Kulissen tragen zur unheimlichen Atmosph\u00e4re bei. Kubrick nimmt sich Zeit, um die Spannung aufzubauen, und verwendet subtile visuelle Effekte, um das Unbehagen zu verst\u00e4rken. 'The Shining' ist nicht nur ein Horrorfilm, sondern auch eine Meditation \u00fcber Isolation, Wahnsinn und die dunklen Abgr\u00fcnde der menschlichen Psyche. Es ist ein Film, der auch nach mehreren Betrachtungen immer noch neue Nuancen und Interpretationen offenbart. Insgesamt ist 'The Shining' ein Meisterwerk des Horrorgenres, das seine Zuschauer mit seiner Intensit\u00e4t und seinem unheimlichen Charme fesselt. Dieser Film ist ein Klassiker, der immer wieder angesehen werden kann und eine unvergleichliche Erfahrung bietet.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "The Shining",
            "type": "Film",
            "Country": "United States",
            "Director": "Stanley Kubrick",
            "Actors": [
                "Jack Nicholson",
                "Shelley Duvall",
                "Danny Lloyd"
            ],
            "Rating": 8.4,
            "Image": "https://images7.alphacoders.com/785/785553.jpg",
            "Genres": [
                "Horror",
                "Psychological Thriller"
            ],
            "InitialRelease": 1980,
            "RunTime": 150,
            "AgeRating": 16,
            "Budget": 19000000
        },
        "User": {
            "Name": "Alice",
            "Email": "alice@example.com",
            "Password": "6P=3UaOX&D"
        },
        "Comment": "Wow, 'The Shining' hat mich echt umgehauen! Jack Nicholsons Performance ist einfach legend\u00e4r und die Atmosph\u00e4re im Film ist durchgehend gruselig. Kubricks Regie ist genial - die Szenen mit den Zwillingen und der Blutflut sind ikonisch. Ein absolutes Must-Watch f\u00fcr Horrorfans!"
    },
    {
        "Id": "Brooklyn 99",
        "Date": "2023-01-02T00:00:00",
        "Description": "Brooklyn Nine-Nine ist eine herausragende Comedy-Serie, die von Michael Schur und Dan Goor geschaffen wurde. Die Handlung dreht sich um das 99. Revier des New Yorker Police Department in Brooklyn und folgt dem Team von Detectives, angef\u00fchrt von Detective Jake Peralta, gespielt von Andy Samberg. Die Serie besticht durch humorvolle Dialoge, skurrile Charaktere und die gelungene Mischung aus Slapstick-Humor und cleveren Wortwitzen. Dabei schafft es die Serie auch, wichtige gesellschaftliche Themen humorvoll anzusprechen. Mit einer Laufzeit von acht Staffeln bietet Brooklyn Nine-Nine st\u00e4ndig frische Ideen und unerwartete Wendungen, die die Zuschauer unterhalten und zum Nachdenken anregen. Eine absolute Empfehlung f\u00fcr Comedy-Fans.",
        "Review": "Brooklyn Nine-Nine ist zweifellos eine herausragende Comedy-Serie und ein wahrer Genuss f\u00fcr Comedy-Fans. Diese Serie, die von Michael Schur und Dan Goor geschaffen wurde, hat sich als eine der beliebtesten und unterhaltsamsten Fernsehserien der letzten Jahre etabliert. Die Handlung dreht sich um das 99. Revier des New Yorker Police Department in Brooklyn und folgt dem bunt gemischten Team von Detectives, angef\u00fchrt von dem chaotischen aber liebenswerten Detective Jake Peralta, gespielt von Andy Samberg. Was diese Serie so besonders macht, ist ihre F\u00e4higkeit, humorvolle Unterhaltung mit tiefgehenden gesellschaftlichen Themen zu verbinden. Brooklyn Nine-Nine schafft es auf einzigartige Weise, ernste Anliegen wie Rassengleichheit, Diversit\u00e4t und soziale Gerechtigkeit in den Kontext einer Comedy-Serie einzubringen, ohne dabei den Unterhaltungswert zu beeintr\u00e4chtigen. Die Art und Weise, wie die Serie diese Themen behandelt, ist erfrischend und zeigt, dass Comedy nicht nur zum Lachen, sondern auch zum Nachdenken anregen kann. Ein herausragendes Element von Brooklyn Nine-Nine sind zweifellos die Charaktere. Jedes Mitglied des Ensembles tr\u00e4gt auf seine eigene Art und Weise zur Komik der Serie bei. Captain Raymond Holt, dargestellt von Andre Braugher, ist ein faszinierendes Beispiel f\u00fcr einen Charakter, der auf den ersten Blick stoisch und ernst wirkt, aber gleichzeitig einen gro\u00dfartigen Sinn f\u00fcr Humor hat. Die toughen Detective Rosa Diaz, gespielt von Stephanie Beatriz, bricht Stereotypen und zeigt, dass Frauen in der Polizeiarbeit genauso erfolgreich sein k\u00f6nnen wie ihre m\u00e4nnlichen Kollegen. Die Serie nimmt sich auch die Freiheit, Konventionen zu brechen und unerwartete Wendungen in die Handlung einzuf\u00fchren. Dies tr\u00e4gt dazu bei, die Spannung und den Unterhaltungswert \u00fcber acht Staffeln hinweg aufrechtzuerhalten. Brooklyn Nine-Nine \u00fcberrascht die Zuschauer immer wieder mit frischen Ideen und neuen Entwicklungen, die die Charaktere und die Handlung vorantreiben. Insgesamt ist Brooklyn Nine-Nine nicht nur eine Comedy-Serie, die uns zum Lachen bringt, sondern auch eine Serie, die dazu anregt, \u00fcber wichtige gesellschaftliche Themen nachzudenken. Sie zeigt, dass Comedy mehr sein kann als nur Unterhaltung \u2013 sie kann auch eine Plattform sein, um Diskussionen anzusto\u00dfen und Ver\u00e4nderungen in der Gesellschaft zu f\u00f6rdern. Eine absolute Empfehlung f\u00fcr jeden, der gute Comedy sch\u00e4tzt und bereit ist, \u00fcber den Tellerrand hinauszuschauen. Diese Serie hat sich einen festen Platz im Herzen vieler Zuschauer verdient und wird noch lange in Erinnerung bleiben.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "Brooklyn 99",
            "type": "Series",
            "Country": "United States",
            "Director": "Michael Schur",
            "Actors": [
                "Andy Samberg",
                "Terry Crews",
                "Stephanie Beatriz",
                "Andre Braugher"
            ],
            "Rating": 8.4,
            "Image": "https://images8.alphacoders.com/566/thumb-1920-566190.jpg",
            "Genres": [
                "Comedy",
                "Police Procedural"
            ],
            "InitialRelease": 2013,
            "Seasons": 3,
            "Episodes": 24,
            "AgeRating": 12,
            "Budget": 50000000
        },
        "User": {
            "Name": "Bob",
            "Email": "bob@example.com",
            "Password": "j[C%RWKzJt"
        },
        "Comment": "Brooklyn 99 ist der Hammer! :D So viel Witz in jeder Episode. Holt ist genial, und die Dynamik im Team ist top! #Noice :P"
    },
    {
        "Id": "Iron Man",
        "Date": "2023-01-01T00:00:00",
        "Description": "Iron Man erz\u00e4hlt die Geschichte von Tony Stark, einem Industriellen, der nach einer Entf\u00fchrung in Afghanistan eine dramatische Ver\u00e4nderung durchmacht. Stark, zuvor ein sorgloser Playboy und genialer Erfinder, wird in eine lebensbedrohliche Situation gebracht, die ihn zwingt, seine Werte zu \u00fcberdenken. Er baut einen fortschrittlichen Anzug, um zu entkommen, und wird zu Iron Man. Zur\u00fcck in den USA, nimmt er den Kampf gegen das B\u00f6se auf, um die Welt vor den Gefahren zu sch\u00fctzen, die er selbst mitgeschaffen hat. Der Film, der in einer Welt voller High-Tech und futuristischer Technologien spielt, erkundet Themen wie Verantwortung, Erl\u00f6sung und Selbstfindung. Die beeindruckenden CGI-Effekte und die Actionsequenzen sind spektakul\u00e4r und dienen der Erz\u00e4hlung, ohne sie zu \u00fcberw\u00e4ltigen. Die Charakterentwicklung, insbesondere die von Stark, ist tiefgr\u00fcndig und glaubw\u00fcrdig. Iron Man kombiniert erfolgreich Elemente von Action, Drama und Humor und schafft so eine mitrei\u00dfende und emotionale Geschichte, die sowohl Superheldenfans als auch ein breiteres Publikum anspricht.",
        "Review": "Iron Man, ein Meilenstein im Marvel Cinematic Universe, ist ein filmisches Kraftwerk, das sich durch seine innovativen Erz\u00e4hltechniken und Robert Downey Jr.s charismatische Darstellung des Tony Stark auszeichnet. Der Film beginnt mit Stark, einem genialen Erfinder und Waffenhersteller, der in Afghanistan entf\u00fchrt wird. In Gefangenschaft baut er einen gepanzerten Anzug und wird zu Iron Man. Diese Wandlung ist der Dreh- und Angelpunkt des Films, der geschickt Action mit emotionaler Tiefe verbindet. Downey Jr. bringt eine facettenreiche Darstellung, die Stark als fehlerhaften, aber liebenswerten Charakter zeigt. Seine Chemie mit Gwyneth Paltrows Pepper Potts und Terrence Howards James Rhodes f\u00fcgt dem Film eine weitere Schicht hinzu. Regisseur Jon Favreau balanciert gekonnt zwischen spektakul\u00e4ren Actionsequenzen und Momenten pers\u00f6nlicher Reflexion. Die visuellen Effekte, insbesondere die Darstellung des Iron Man-Anzugs, sind bahnbrechend und tragen wesentlich zur Faszination des Films bei. Der Soundtrack von Ramin Djawadi unterstreicht die spannende Atmosph\u00e4re. Insgesamt ist Iron Man nicht nur ein technisches Meisterwerk, sondern auch ein tiefgreifendes, charaktergetriebenes Drama, das das Superheldengenre neu definiert hat.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "Iron Man",
            "type": "Film",
            "Country": "United States",
            "Director": "Jon Favreau",
            "Actors": [
                "Robert Downey Jr.",
                "Gwyneth Paltrow",
                "Terrence Howard"
            ],
            "Rating":7.9,
            "Image": "https://images2.alphacoders.com/105/1051995.jpg",
            "Genres": [
                "Action",
                "Superhero"
            ],
            "InitialRelease": 2008,
            "RunTime": 126,
            "AgeRating": 12,
            "Budget": 140000000
        },
        "User": {
            "Name": "Charlie",
            "Email": "charlie@example.com",
            "Password": "K-A#Ng12d<"
        },
        "Comment": "Iron Man setzt neue Ma\u00dfst\u00e4be im Superhelden-Genre. Die Kombination aus Downey Jrs. charismatischer Darstellung und den innovativen Spezialeffekten macht den Film zu einem echten Erlebnis. Ein beeindruckender Start f\u00fcr das Marvel Cinematic Universe!"
    },
    {
        "Id": "The Lord of the Rings: The Fellowship of the Ring",
        "Date": "2023-01-02T00:00:00",
        "Description": "Der Herr der Ringe Die Gef\u00e4hrten beginnt die epische Erz\u00e4hlung von J.R.R. Tolkiens legend\u00e4rem Fantasy-Epos. Der Film folgt der Reise des jungen Hobbits Frodo Beutlin, der eine gef\u00e4hrliche Aufgabe \u00fcbernimmt: den Ring der Macht zu zerst\u00f6ren, der vom dunklen Herrscher Sauron geschaffen wurde. Frodo wird von einer Gruppe von Gef\u00e4hrten begleitet, darunter der weise Zauberer Gandalf, der mutige Mensch Aragorn, der geschickte Bogensch\u00fctze Legolas und der starke Zwerg Gimli. Ihre Reise f\u00fchrt sie durch verschiedene Landschaften von Mittelerde, von den friedlichen Auenlandschaften bis zu den dunklen Minen von Moria. Der Film ist ein visuelles Spektakel mit atemberaubenden Landschaftsaufnahmen und detaillierten Sets, die die Vielfalt und Sch\u00f6nheit von Mittelerde einfangen. Die Charaktere sind tiefgr\u00fcndig und vielschichtig, jeder mit seiner eigenen Geschichte und seinen Beweggr\u00fcnden. Die Handlung ist fesselnd und voller unerwarteter Wendungen, w\u00e4hrend sie Themen wie Freundschaft, Mut und Opferbereitschaft erkundet. Die Spezialeffekte, insbesondere die Darstellung der Kreaturen und der Kampfszenen, sind beeindruckend und tragen zur Glaubw\u00fcrdigkeit der Fantasiewelt bei. Der Herr der Ringe Die Gef\u00e4hrten ist nicht nur ein Film, sondern eine Reise in eine andere Welt, die das Publikum mit ihrer Detailtiefe und ihrem emotionalen Tiefgang fesselt.",
        "Review": "Der Herr der Ringe Die Gef\u00e4hrten, der erste Teil der epischen Trilogie von Peter Jackson, basierend auf J.R.R. Tolkiens gleichnamigem Meisterwerk, ist ein filmisches Abenteuer von monumentalem Ausma\u00df. Der Film entf\u00fchrt in die Welt von Mittelerde, wo der junge Hobbit Frodo Beutlin die gewaltige Aufgabe erh\u00e4lt, einen m\u00e4chtigen Ring zu zerst\u00f6ren, um das B\u00f6se zu besiegen. Die Darstellung der Welt Mittelerdes ist atemberaubend, mit liebevoll gestalteten Landschaften, die von den neuseel\u00e4ndischen Alpen bis zu den malerischen H\u00fcgeln des Auenlands reichen. Die Besetzung, darunter Elijah Wood als Frodo, Ian McKellen als Gandalf und Viggo Mortensen als Aragorn, bringt die vielschichtigen Charaktere mit einer Leidenschaft und Tiefe zum Leben, die selten in Fantasy-Filmen zu sehen ist. Besonders hervorzuheben sind die visuellen Effekte und das Make-up, die Kreaturen wie Orks, Elben und Zwerge glaubhaft darstellen. Howard Shores eindringliche Musikuntermalung verst\u00e4rkt die epische und oft emotionale Atmosph\u00e4re des Films. Die Regie von Jackson ist bemerkenswert, indem er Tolkiens detaillierte Welt treu auf die Leinwand bringt und dabei eine Balance zwischen spektakul\u00e4rer Action, tiefgreifender Charakterentwicklung und poetischer Erz\u00e4hlung h\u00e4lt. Dieser Film ist nicht nur eine technische Meisterleistung, sondern auch ein Triumph des Geschichtenerz\u00e4hlens, der die Zuschauer in eine Welt entf\u00fchrt, die gleichzeitig fantastisch und zutiefst menschlich ist.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "The Lord of the Rings: The Fellowship of the Ring",
            "type": "Film",
            "Country": "United Kingdom",
            "Director": "Peter Jackson",
            "Actors": [
                "Fran Walsh",
                "Philippa Boyens",
                "Peter Jackson"
            ],
            "Rating": 8.8,
            "Image": "https://m.media-amazon.com/images/S/pv-target-images/b9f4dd7d3f9fa2cb36c757c7aecb690e8fc416e4165eb2d68d5fbdb837a19541.jpg",
            "Genres": [
                "Fantasy",
                "Action",
                "Adventure"
            ],
            "InitialRelease": 2001,
            "RunTime": 178,
            "AgeRating": 12,
            "Budget": 93000000
        },
        "User": {
            "Name": "Diana",
            "Email": "diana@example.com",
            "Password": "0]'c<8p8,2"
        },
        "Comment": "Die Gef\u00e4hrten ist ein episches Meisterwerk. Die Adaption von Tolkiens Welt ist atemberaubend und die Darstellungen sind hervorragend. Ein triumphaler Auftakt f\u00fcr die Trilogie, der die Messlatte f\u00fcr Fantasy-Filme hoch setzt."
    },
    {
        "Id": "Joker",
        "Date": "2023-01-01T00:00:00",
        "Description": "Joker, angesiedelt in einer alternativen Version von Gotham City in den fr\u00fchen 1980er Jahren, erz\u00e4hlt die Geschichte von Arthur Fleck, einem Mann, der von der Gesellschaft versto\u00dfen und in die Ecke getrieben wird. Fleck, ein Clown und gescheiterter Stand-up-Comedian, k\u00e4mpft mit psychischen Problemen und einem Leben voller Ablehnung und Dem\u00fctigung. Im Laufe des Films erleben wir, wie die st\u00e4ndigen R\u00fcckschl\u00e4ge und die Grausamkeit der Menschen um ihn herum ihn in den Wahnsinn treiben und schlie\u00dflich zu seiner Transformation in den ikonischen Joker f\u00fchren. Der Film ist eine tiefgehende Charakterstudie, die sich mit Themen wie psychischer Gesundheit, gesellschaftlicher Entfremdung und dem d\u00fcnnen Grat zwischen Vernunft und Wahnsinn auseinandersetzt. Die d\u00fcstere und bedr\u00fcckende Atmosph\u00e4re des Films wird durch die detaillierte Darstellung von Gotham City als Stadt am Rande des Chaos verst\u00e4rkt. Phoenixs Performance als Arthur Fleck ist das Herzst\u00fcck des Films, seine F\u00e4higkeit, die Komplexit\u00e4t und Tragik des Charakters einzufangen, macht den Film zu einem packenden Erlebnis. Joker ist kein typischer Superheldenfilm, sondern ein d\u00fcsteres, psychologisches Drama, das die Zuschauer sowohl fesselt als auch herausfordert.",
        "Review": "Joker, unter der Regie von Todd Phillips und mit Joaquin Phoenix in der Titelrolle, ist ein meisterhaft inszenierter Film, der sich von traditionellen Comicbuch-Verfilmungen abhebt. Der Film erz\u00e4hlt die Geschichte von Arthur Fleck, einem gescheiterten Comedian in Gotham City, dessen langsamer Abstieg in den Wahnsinn sowohl faszinierend als auch beunruhigend ist. Phoenixs Darstellung von Fleck/Joker ist atemberaubend und unvergesslich, er f\u00e4ngt jede Nuance von Arthurs gebrochener Psyche ein. Seine Leistung ist nicht nur eine Darstellung von Wahnsinn, sondern auch eine tiefgehende Auseinandersetzung mit menschlichem Leid und Isolation. Die d\u00fcstere Atmosph\u00e4re des Films, verst\u00e4rkt durch die karge und d\u00fcstere \u00c4sthetik von Gotham, schafft ein Gef\u00fchl der Beklemmung, das den Zuschauer umf\u00e4ngt. Die Handlung, die sich um Themen wie soziale Ungerechtigkeit und moralischen Verfall dreht, ist provokativ und fordert den Zuschauer heraus, sich mit komplexen sozialen und psychologischen Fragen auseinanderzusetzen. Die Regie von Phillips ist k\u00fchn und unerschrocken, er schafft es, einen Film zu liefern, der sowohl eine charaktergetriebene Studie als auch eine d\u00fcstere Erkundung einer Gesellschaft am Rande des Zusammenbruchs ist. Die Filmmusik von Hildur Gu\u00f0nad\u00f3ttir, die sowohl bedrohlich als auch emotional ist, tr\u00e4gt wesentlich zur gespannten Stimmung des Films bei. Joker ist ein kraftvolles, st\u00f6rendes und letztlich unvergessliches Kinoerlebnis, das die Grenzen dessen, was ein Comicbuch-Film sein kann, neu definiert.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "Joker",
            "type": "Film",
            "Country": "United States",
            "Director": "Todd Phillips",
            "Actors": [
                "Zazie Beetz",
                "Joaquin Phoenix",
                "Robert De Niro"
            ],
            "Rating": 8.4,
            "Image": "https://images3.alphacoders.com/103/1039332.jpg",
            "Genres": [
                "Unknown Genre"
            ],
            "InitialRelease": 2019,
            "RunTime": 122,
            "AgeRating": 16,
            "Budget": 55000000
        },
        "User": {
            "Name": "Ethan",
            "Email": "ethan@example.com",
            "Password": "bWW*6)$@.o"
        },
        "Comment": "Joker ist intensiv und verst\u00f6rend. Joaquin Phoenix liefert eine Oscar-reife Performance. Ein d\u00fcsterer, nachdenklicher Film."
    },
    {
        "Id": "post2",
        "Date": "2023-01-02T00:00:00",
        "Description": "In Der Herr der Ringe Die R\u00fcckkehr des K\u00f6nigs erreicht die epische Erz\u00e4hlung von J.R.R. Tolkiens Mittelerde ihr atemberaubendes Finale. Der Film folgt der Fortsetzung der Reise des Hobbits Frodo und seines treuen Freundes Sam, die den Ring der Macht zum Schicksalsberg bringen m\u00fcssen, um Saurons Herrschaft zu beenden. Parallel dazu r\u00fcsten sich die vereinten Streitkr\u00e4fte von Menschen, Elben und Zwergen f\u00fcr die entscheidende Schlacht gegen Saurons Armeen. Aragorns Reise zur Akzeptanz seiner Bestimmung als K\u00f6nig ist zentral f\u00fcr die Handlung, ebenso wie die Entwicklung anderer Schl\u00fcsselfiguren wie Gandalf, Legolas und Gimli. Der Film ist gekennzeichnet durch seine epischen Schlachtszenen, insbesondere die Belagerung von Minas Tirith, die in ihrer Gr\u00f6\u00dfenordnung und Inszenierung beeindruckend sind. Die visuelle Darstellung von Mittelerde ist weiterhin herausragend, mit atemberaubenden Landschaften und detaillierten St\u00e4dten, die eine lebendige und glaubw\u00fcrdige Welt schaffen. Die emotionale Tiefe des Films, verst\u00e4rkt durch die intensiven Darbietungen der Schauspieler und die ergreifende Filmmusik, macht Die R\u00fcckkehr des K\u00f6nigs zu einem bewegenden und unvergesslichen Kinoerlebnis. Der Film schlie\u00dft die Trilogie ab und hinterl\u00e4sst ein Gef\u00fchl der Erf\u00fcllung und Bewunderung f\u00fcr die Leistung, eine der gr\u00f6\u00dften literarischen Werke des 20. Jahrhunderts auf die Leinwand gebracht zu haben.",
        "Review": "Der Herr der Ringe Die R\u00fcckkehr des K\u00f6nigs, der abschlie\u00dfende Teil von Peter Jacksons monumentaler Verfilmung von J.R.R. Tolkiens Epos, ist ein Triumph des Fantasy-Kinos. Der Film setzt die epische Geschichte von Mittelerde fort und f\u00fchrt die zahlreichen Handlungsstr\u00e4nge zu einem atemberaubenden Finale zusammen. Der Fokus auf die Schlacht um Minas Tirith und Frodos letzte Etappe zum Schicksalsberg ist meisterhaft inszeniert und h\u00e4lt das Publikum in anhaltender Spannung. Elijah Wood als Frodo und Sean Astin als sein treuer Begleiter Sam zeigen herausragende schauspielerische Leistungen, die die emotionale Tiefe ihrer Reise unterstreichen. Ian McKellen als Gandalf und Viggo Mortensen als Aragorn f\u00fcllen ihre Rollen mit W\u00fcrde und Kraft aus, was den Zuschauer tief in das Geschehen eintauchen l\u00e4sst. Die visuellen Effekte sind atemberaubend und setzen neue Ma\u00dfst\u00e4be f\u00fcr zuk\u00fcnftige Filme. Besonders beeindruckend sind die Szenen der gewaltigen Schlachten, die mit einer unglaublichen Detailgenauigkeit und visuellen Brillanz umgesetzt wurden. Howard Shores musikalische Untermalung ist erneut ein Meisterwerk, das die emotionale Wirkung jeder Szene verst\u00e4rkt. Die R\u00fcckkehr des K\u00f6nigs ist nicht nur ein visuelles Spektakel, sondern auch eine tiefe und bewegende Erz\u00e4hlung \u00fcber Freundschaft, Opfer und den endg\u00fcltigen Triumph des Guten \u00fcber das B\u00f6se. Dieser Film ist ein w\u00fcrdiger Abschluss einer der gr\u00f6\u00dften Filmtrilogien aller Zeiten und hinterl\u00e4sst ein unvergessliches Erbe in der Welt des Kinos.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "The Lord of the Rings: The Return of the King",
            "type": "Film",
            "Country": "New Zealand",
            "Director": "Peter Jackson",
            "Actors": [
                "J.R.R Tolkien",
                "Fran Walsh",
                "Philippa Boyens"
            ],
            "Rating": 9.0,
            "Image": "https://m.media-amazon.com/images/S/pv-target-images/5512407f08ec366090998fc9434afb8124bef7a8a68c9a78738c7ff50dbad835.jpg",
            "Genres": [
                "Fantasy",
                "Action",
                "Adventure"
            ],
            "InitialRelease": 2003,
            "RunTime": 210,
            "AgeRating": 12,
            "Budget": 94000000
        },
        "User": {
            "Name": "Fiona",
            "Email": "fiona@example.com",
            "Password": "a|>8O!q|$r"
        },
        "Comment": "Die R\u00fcckkehr des K\u00f6nigs ist ein triumphaler Abschluss der Trilogie. Epische Schlachten, tiefgr\u00fcndige Charaktere und eine emotionale Tiefe, die ihresgleichen sucht."
    },
    {
        "Id": "post1",
        "Date": "2023-01-01T00:00:00",
        "Description": "In Der Herr der Ringe Die Zwei T\u00fcrme, der Fortsetzung der epischen Trilogie, spaltet sich die Gef\u00e4hrtengruppe in mehrere Pfade auf. Frodo und Sam setzen ihre Reise zum Schicksalsberg fort, um den Ring der Macht zu zerst\u00f6ren, und werden dabei von Gollum begleitet, einer zerrissenen Figur, die einst der Ringhalter war. Aragorn, Legolas und Gimli verfolgen die Spur der entf\u00fchrten Hobbits Merry und Pippin und finden sich bald in der Schlacht um das K\u00f6nigreich Rohan wieder. Dieser Teil der Trilogie vertieft die komplexe Welt Mittelerdes und stellt neue Charaktere und Schaupl\u00e4tze vor, darunter den Zauberer Saruman in Isengart und die Bewohner von Rohan. Die Schlacht um Helms Klamm, eine der Hauptattraktionen des Films, ist ein visuelles und emotionales Spektakel, das die Zuschauer mit seiner Intensit\u00e4t und seinem Umfang in den Bann zieht. Die Erz\u00e4hlung wechselt geschickt zwischen den verschiedenen Handlungsstr\u00e4ngen und beh\u00e4lt dabei stets den narrativen Fluss und die Spannung bei. Die Zwei T\u00fcrme baut auf den Grundlagen des ersten Films auf und setzt die Geschichte mit einer Kombination aus monumentaler Action, tiefgr\u00fcndiger Charakterentwicklung und einer reichen mythologischen Tiefe fort. Der Film ist nicht nur eine beeindruckende technische Leistung, sondern auch ein emotionales und packendes Kinoerlebnis, das die Zuschauer auf eine epische Reise durch eine der faszinierendsten Fantasy-Welten mitnimmt.",
        "Review": "Der Herr der Ringe Die Zwei T\u00fcrme, der zweite Teil der epischen Trilogie von Peter Jackson, setzt die fesselnde Erz\u00e4hlung von J.R.R. Tolkiens Mittelerde fort und vertieft sie auf eindrucksvolle Weise. Dieser Film, der die parallelen Wege der nun getrennten Mitglieder der Gef\u00e4hrten verfolgt, zeichnet sich durch seine geschickte Vermischung von intensiver Charakterentwicklung und spektakul\u00e4rer Action aus. Die Einf\u00fchrung neuer Schl\u00fcsselfiguren wie Gollum, gespielt von Andy Serkis in einer bahnbrechenden Performance-Capture-Rolle, und der Menschen von Rohan, einschlie\u00dflich K\u00f6nig Th\u00e9oden und \u00c9owyn, bereichert die schon vielschichtige Welt Mittelerdes. Besonders hervorzuheben sind die Schlacht um die Hornburg und die Verteidigung von Helms Klamm, die zu den beeindruckendsten und packendsten Schlachtszenen in der Filmgeschichte geh\u00f6ren. Die visuellen Effekte, die sowohl die Kreaturen von Tolkiens Welt als auch die gewaltigen Landschaften und Schlachten zum Leben erwecken, sind atemberaubend und ein technisches Meisterwerk. Die musikalische Untermalung von Howard Shore f\u00e4ngt die epische und emotionale Atmosph\u00e4re des Films perfekt ein. Die Zwei T\u00fcrme gelingt es nicht nur, die Geschichte nahtlos weiterzuerz\u00e4hlen, sondern auch die Spannung und Erwartung f\u00fcr das gro\u00dfe Finale der Trilogie zu steigern. Dieser Film ist ein herausragendes Beispiel f\u00fcr die M\u00f6glichkeiten des Fantasy-Genres und ein Beweis f\u00fcr Jacksons Vision und Talent als Regisseur.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "The Lord of the Rings: The Two Towers",
            "type": "Film",
            "Country": "New Zealand",
            "Director": "Peter Jackson",
            "Actors": [
                "J.R.R Tolkien",
                "Fran Walsh",
                "Philippa Boyens"
            ],
            "Rating": 8.8,
            "Image": "https://wallpapercave.com/wp/wp4119912.jpg",
            "Genres": [
                "Fantasy",
                "Action",
                "Adventure"
            ],
            "InitialRelease": 2002,
            "RunTime": 179,
            "AgeRating": 12,
            "Budget": 94000000
        },
        "User": {
            "Name": "George",
            "Email": "george@example.com",
            "Password": "?nk1Deify:"
        },
        "Comment": "Die zwei T\u00fcrme beeindruckt mit grandiosen Schlachtszenen und tiefgehender Charakterentwicklung. Ein fesselnder Mittelteil der epischen Trilogie."
    },
    {
        "Id": "post2",
        "Date": "2023-01-02T00:00:00",
        "Description": "The Boys, angesiedelt in einem Universum, in dem Superhelden als Ber\u00fchmtheiten und m\u00e4chtige Einflussfiguren existieren, stellt die dunkle Seite des Heldentums in den Vordergrund. Die Serie beginnt mit einem traumatischen Ereignis, das Hughie Campbell, gespielt von Jack Quaid, dazu veranlasst, sich den Boys anzuschlie\u00dfen, einer Gruppe von Vigilanten, die gegen die korrupten und moralisch fragw\u00fcrdigen Taten der Superhelden k\u00e4mpfen. Diese Superhelden, von einem m\u00e4chtigen Konzern namens Vought International kontrolliert, nutzen ihre Kr\u00e4fte und ihren Einfluss h\u00e4ufig zu pers\u00f6nlichen Zwecken. Die Serie erforscht die komplexen Beziehungen zwischen den Boys und den Supes, wobei sie die grauen Bereiche von Gut und B\u00f6se auslotet. Die Charakterentwicklung ist ein zentrales Element der Serie, wobei jede Figur eine eigene, oft schmerzhafte Geschichte hat. Die Serie kombiniert Elemente von Drama, Thriller und schwarzer Kom\u00f6die und ist bekannt f\u00fcr ihre expliziten Gewaltdarstellungen und ihren oft schockierenden Inhalt. The Boys bricht mit den Konventionen des Superheldengenres und bietet eine zynische, aber faszinierende Sicht auf eine Welt, in der Superhelden nicht die Retter sind, die sie zu sein scheinen.",
        "Review": "The Boys, eine Serie, die im Superheldengenre neue Ma\u00dfst\u00e4be setzt, ist eine provokative und zynische Darstellung einer Welt, in der Superhelden existieren, aber weit entfernt von den idealisierten Figuren der Comicb\u00fccher sind. Die Serie, basierend auf den Comics von Garth Ennis und Darick Robertson, wird von Eric Kripke meisterhaft inszeniert und bietet eine d\u00fcstere, satirische Sicht auf Superhelden, die mehr von ihren eigenen Interessen als von moralischen Prinzipien geleitet werden. Die Geschichte folgt einer Gruppe von Vigilanten, bekannt als The Boys, angef\u00fchrt von Billy Butcher, gespielt von Karl Urban, die sich zusammenschlie\u00dfen, um die Korruption und den Missbrauch der Superhelden, bekannt als Supes, aufzudecken und zu bek\u00e4mpfen. Die Charaktere sind tiefgr\u00fcndig und vielschichtig, mit eindrucksvollen Darstellungen, die sowohl die menschlichen Schw\u00e4chen als auch die dunkleren Aspekte des Heldentums beleuchten. Besonders hervorzuheben ist Anthony Starrs Darstellung des Homelander, eines m\u00e4chtigen und manipulativen Supes, der die moralische Ambivalenz der Serie verk\u00f6rpert. Die Handlung ist voller unerwarteter Wendungen und bietet eine scharfe Kritik an Machtmissbrauch, Korporatismus und der Celebrity-Kultur. The Boys ist eine Serie, die nicht nur durch ihre actiongeladenen Szenen und spektakul\u00e4ren visuellen Effekte fesselt, sondern auch durch ihre intelligente Erz\u00e4hlung und sozialkritischen Kommentare.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "The Boys",
            "type": "Series",
            "Country": "United States",
            "Director": "Eric Kripke",
            "Actors": [
                "Karl Urban",
                "Antony Starr",
                "Jack Quaid"
            ],
            "Rating": 8.7,
            "Image": "https://images.hdqwalls.com/wallpapers/the-boys-tv-show-2019-5k-28.jpg",
            "Genres": [
                "Action",
                "Comedy"
            ],
            "InitialRelease": 2019,
            "Seasons": 3,
            "Episodes": 24,
            "AgeRating": 18,
            "Budget": 51200000
        },
        "User": {
            "Name": "Hannah",
            "Email": "hannah@example.com",
            "Password": "2oJx+Oz9)^"
        },
        "Comment": "The Boys ist eine absolute Frischluftzufuhr im Superhelden-Genre. Diese Serie sticht mit ihrer rohen, ungesch\u00f6nten Darstellung der Superheldenwelt hervor. Sie hinterfragt die Idee des Helden und zeigt die dunklen Seiten von Macht und Ber\u00fchmtheit. Die Charaktere sind vielschichtig und faszinierend, besonders Homelander und Billy Butcher sind herausragend gespielt. Die Handlung ist spannend und unvorhersehbar, mit einer Prise schwarzen Humors, die perfekt zur d\u00fcsteren Atmosph\u00e4re passt. 'The Boys' ist definitiv nichts f\u00fcr schwache Nerven, aber f\u00fcr Fans des Genres, die etwas Neues suchen, ein absolutes Muss."
    },
    {
        "Id": "post2",
        "Date": "2023-01-02T00:00:00",
        "Description": "In No Country for Old Men, angesiedelt im Texas der 1980er Jahre, stolpert Llewelyn Moss zuf\u00e4llig \u00fcber die \u00dcberreste eines Drogendeals, der schiefgelaufen ist, und entdeckt dabei zwei Millionen Dollar. Sein Entschluss, das Geld zu behalten, zieht die Aufmerksamkeit des psychopathischen Killers Anton Chigurh auf sich, der mit einem Druckluftbolzenschussger\u00e4t und einem unersch\u00fctterlichen Sinn f\u00fcr sein eigenes verdrehtes moralisches Gesetz ausgestattet ist. W\u00e4hrend Moss versucht, seinen Verfolgern zu entkommen, wird die Geschichte auch aus der Perspektive von Sheriff Ed Tom Bell erz\u00e4hlt, einem alternden Gesetzesh\u00fcter, der \u00fcber seine F\u00e4higkeit, Gerechtigkeit in einer sich ver\u00e4ndernden und moralisch komplexen Welt zu bewahren, nachdenkt. Der Film ist ein intensiver, oft brutaler Thriller, der sich durch seine authentische Darstellung des l\u00e4ndlichen Texas und seine scharfen, minimalistischen Dialoge auszeichnet. Die Regie der Coen-Br\u00fcder ist pr\u00e4zise und kontrolliert, wobei jeder Schuss und jede Szene sorgf\u00e4ltig gestaltet ist, um die intensive Atmosph\u00e4re und die tieferen Themen des Films zu unterstreichen. No Country for Old Men ist ein packender, nachdenklicher und tiefgr\u00fcndiger Film, der die Zuschauer lange nach dem Ende besch\u00e4ftigt.",
        "Review": "No Country for Old Men, ein Meisterwerk der Coen-Br\u00fcder, ist ein filmisches Erlebnis, das sich durch seine straffe Erz\u00e4hlung, fesselnde Charaktere und eine Atmosph\u00e4re der unheilvollen Spannung auszeichnet. Der Film, basierend auf dem Roman von Cormac McCarthy, erz\u00e4hlt die Geschichte von Llewelyn Moss, gespielt von Josh Brolin, der nach dem Fund von zwei Millionen Dollar in der texanischen W\u00fcste in ein t\u00f6dliches Katz-und-Maus-Spiel mit dem gnadenlosen Killer Anton Chigurh, meisterhaft dargestellt von Javier Bardem, verwickelt wird. Tommy Lee Jones als Sheriff Ed Tom Bell bietet eine nuancierte Darstellung eines Gesetzesh\u00fcters, der sich mit dem wachsenden B\u00f6sen und dem moralischen Verfall in der modernen Welt konfrontiert sieht. Der Film zeichnet sich durch seine minimalistische Erz\u00e4hlweise und den Verzicht auf konventionelle Musikuntermalung aus, was die Spannung und das Gef\u00fchl der Bedrohung erh\u00f6ht. Die Landschaften von Texas werden eindrucksvoll eingefangen und tragen zur d\u00fcsteren und bedr\u00fcckenden Atmosph\u00e4re bei. Die Dialoge sind pr\u00e4gnant und voller Bedeutung, w\u00e4hrend die Handlung eine tiefgreifende Auseinandersetzung mit Themen wie Schicksal, Moral und der unerbittlichen Natur des B\u00f6sen bietet. No Country for Old Men ist nicht nur ein Thriller, sondern auch eine philosophische Betrachtung der menschlichen Natur und der unausweichlichen Konfrontation mit dem B\u00f6sen in der Welt.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "No Country for old Men",
            "type": "Film",
            "Country": "United States",
            "Director": "Ethan Coen",
            "Actors": [
                "Tommy Lee Jones",
                "Javier Bardem",
                "Jost Brolin"
            ],
            "Rating": 8.2,
            "Image": "https://images6.alphacoders.com/112/1126390.jpg",
            "Genres": [
                "Crime",
                "Drama"
            ],
            "InitialRelease": 2007,
            "RunTime": 122,
            "AgeRating": 16,
            "Budget": 25000000
        },
        "User": {
            "Name": "Ian",
            "Email": "ian@example.com",
            "Password": "Pc'bgP_5W("
        },
        "Comment": "No Country for Old Men ist ein fesselnder Thriller, der einen von Anfang bis Ende in seinen Bann zieht. Die Regie der Coen-Br\u00fcder ist meisterhaft, und Javier Bardems Darstellung des unerbittlichen Killers Anton Chigurh ist einfach atemberaubend. Die d\u00fcstere, spannungsgeladene Atmosph\u00e4re und die tiefgr\u00fcndigen Themen von Moral und Schicksal machen diesen Film zu einem modernen Klassiker. Die ruhige Erz\u00e4hlweise und die intensiven Charakterstudien heben ihn von typischen Thrillern ab. Ein absolutes Meisterwerk!"
    },
    {
        "Id": "post10",
        "Date": "2023-01-10T00:00:00",
        "Description": "Pulp Fiction entfaltet eine Reihe miteinander verbundener Geschichten, die sich in der Unterwelt von Los Angeles abspielen. Die Hauptfiguren sind Vincent Vega und Jules Winnfield, zwei Auftragskiller, die f\u00fcr einen Gangsterboss arbeiten. Ihre Wege kreuzen sich mit denen einer Vielzahl anderer Charaktere, darunter Mia Wallace, die Frau ihres Chefs, und Butch Coolidge, ein Boxer, der in einer verzwickten Lage steckt. Jede Geschichte enth\u00e4lt Elemente von Gewalt, Humor und unerwarteten Wendungen, die typisch f\u00fcr Tarantinos Stil sind. Der Film spielt mit verschiedenen Genres und Erz\u00e4hlstilen, von der Gangster-Kom\u00f6die bis zum dramatischen Thriller, und kreiert dabei ein einzigartiges filmisches Universum. Die Dialoge sind pointiert, geistreich und oft mit philosophischen und popkulturellen Anspielungen durchsetzt. Visuell ist der Film eine Hommage an die \u00c4sthetik der Pulp-Magazine und Film Noir-Klassiker, mit einer zeitgen\u00f6ssischen Drehung. Pulp Fiction ist ein bahnbrechender Film, der f\u00fcr seine k\u00fchne Erz\u00e4hlweise, seinen unverwechselbaren Stil und seine F\u00e4higkeit, konventionelle Filmkonventionen zu durchbrechen, gefeiert wird.",
        "Review": "Pulp Fiction, eines der ikonischsten Werke von Quentin Tarantino, ist ein Paradebeispiel f\u00fcr innovatives Filmemachen, das das Genre des Kriminalfilms neu definiert hat. Der Film ist bekannt f\u00fcr seine nichtlineare Erz\u00e4hlstruktur, scharfen Dialoge und unvergesslichen Charaktere. Die Geschichte verwebt mehrere Handlungsstr\u00e4nge, die sich um die Leben von zwei Auftragskillern, Vincent Vega und Jules Winnfield, einer verungl\u00fcckten Restaurant\u00fcberfall-Planung und einer Boxkampfmanipulation drehen. John Travolta, Samuel L. Jackson, Uma Thurman und Bruce Willis liefern herausragende Leistungen, die ihre Figuren unvergesslich machen. Tarantinos Regie ist gekennzeichnet durch seinen einzigartigen Stil, der eine Mischung aus scharfem Witz, pl\u00f6tzlicher Gewalt und kulturellen Verweisen bietet. Der Soundtrack des Films, eine sorgf\u00e4ltig ausgew\u00e4hlte Mischung aus Rock, Soul und Surf-Musik, erg\u00e4nzt die Handlung perfekt und hat sich als ebenso ikonisch erwiesen wie der Film selbst. Pulp Fiction ist nicht nur ein Film, sondern ein Kulturgut, das das moderne Kino ma\u00dfgeblich beeinflusst hat. Es ist ein Film, der sowohl die dunklen Aspekte des Lebens als auch die absurden Momente des Zufalls und Schicksals erforscht und dabei stets unterhaltsam und fesselnd bleibt.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "Pulp Fiction",
            "type": "Film",
            "Country": "United States",
            "Director": "Quentin Tarantino",
            "Actors": [
                "John Travolta",
                "Uma Thurman",
                "Samuel L. Jackson"
            ],
            "Rating": 8.9,
            "Image": "https://images7.alphacoders.com/693/693715.jpg",
            "Genres": [
                "Crime",
                "Drama"
            ],
            "InitialRelease": 1994,
            "RunTime": 154,
            "AgeRating": 16,
            "Budget": 8500000
        },
        "User": {
            "Name": "Julia",
            "Email": "julia@example.com",
            "Password": "s]M`o4\\F5="
        },
        "Comment": "Pulp Fiction ist pure Klasse! :D Tarantinos einzigartiger Stil und die clever verkn\u00fcpften Geschichten sind spitze. Travolta und Jackson sind einfach unschlagbar! ;) Ein absoluter Muss-Film. #Kult :P"
    },
    {
        "Id": "post10",
        "Date": "2023-01-10T00:00:00",
        "Description": "The Avengers: Infinity War ist ein episches Superhelden-Abenteuer, das Charaktere aus dem gesamten Marvel Cinematic Universe zusammenbringt. Die zentrale Handlung dreht sich um Thanos, einen m\u00e4chtigen intergalaktischen Tyrannen, der bestrebt ist, alle sechs Infinity-Steine zu sammeln. Sein Ziel ist es, mit deren Macht das Gleichgewicht im Universum wiederherzustellen, indem er die H\u00e4lfte aller Lebewesen ausl\u00f6scht. Die Avengers, geteilt und geschw\u00e4cht durch fr\u00fchere Konflikte, m\u00fcssen ihre Differenzen beiseitelegen und sich mit anderen Helden wie den Guardians of the Galaxy, Doctor Strange und Black Panther vereinen, um Thanos zu stoppen. Der Film f\u00fchrt die Zuschauer auf eine Reise durch verschiedene Welten, von der Erde bis zum fernen Titan, und ist gepr\u00e4gt von spektakul\u00e4ren Schlachten und emotionalen Momenten. Die Interaktionen und Beziehungen zwischen den verschiedenen Charakteren bieten humorvolle, herzliche und manchmal herzzerrei\u00dfende Momente. Infinity War ist ein filmisches Spektakel, das die Grenzen des Superheldengenres erweitert und gleichzeitig eine tiefgr\u00fcndige Geschichte \u00fcber Heldentum, Opfer und die Konsequenzen von Macht erz\u00e4hlt.",
        "Review": "The Avengers: Infinity War, ein H\u00f6hepunkt des Marvel Cinematic Universe, ist ein beeindruckendes Zusammentreffen von Charakteren und Handlungsstr\u00e4ngen, das \u00fcber ein Jahrzehnt an filmischer Erz\u00e4hlung kulminiert. Unter der Regie von Joe und Anthony Russo vereint der Film eine beispiellose Anzahl von Superhelden, um sich der Bedrohung durch Thanos, eindrucksvoll dargestellt von Josh Brolin, zu stellen. Der Film besticht durch seine F\u00e4higkeit, eine Vielzahl von Charakteren zu balancieren, ohne dabei an Tiefe oder Fokus zu verlieren. Jeder Charakter, von Iron Man und Thor bis zu den Guardians of the Galaxy, erh\u00e4lt Momente, in denen er gl\u00e4nzen kann. Die Handlung, die das Universum durchquert, ist sowohl episch in ihrem Umfang als auch emotional packend. Besonders hervorzuheben ist die Darstellung von Thanos, der nicht nur als allm\u00e4chtiger Antagonist, sondern auch als komplexer Charakter mit eigenen \u00dcberzeugungen und Emotionen pr\u00e4sentiert wird. Die visuellen Effekte sind atemberaubend und tragen ma\u00dfgeblich zur Erschaffung beeindruckender Welten und actionreicher Schlachten bei. Infinity War ist nicht nur ein Actionfilm, sondern auch eine Geschichte \u00fcber Opfer, Verlust und die Konsequenzen von Macht. Der Film endet mit einem der k\u00fchnsten und \u00fcberraschendsten Cliffhanger der Filmgeschichte und hinterl\u00e4sst das Publikum in gespannter Erwartung auf das Finale.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "The Avengers - Infinity War",
            "type": "Film",
            "Country": "United States",
            "Director": "Anthony Russo",
            "Actors": [
                "Robert Downey Jr.",
                "Chris Hemsworth",
                "Mark Ruffalo"
            ],
            "Rating": 8.4,
            "Image": "https://images4.alphacoders.com/909/thumb-1920-909185.jpg",
            "Genres": [
                "Action",
                "Adventure"
            ],
            "InitialRelease": 2018,
            "RunTime": 149,
            "AgeRating": 12,
            "Budget": 360000000
        },
        "User": {
            "Name": "Karoline",
            "Email": "Karoline@example.com",
            "Password": "Zt0tYTo}5|"
        },
        "Comment": "Infinity War ist ein episches Spektakel! :O Die Zusammenf\u00fchrung so vieler Charaktere funktioniert erstaunlich gut. Thanos ist ein beeindruckender B\u00f6sewicht. :| Das Ende l\u00e4sst einen sprachlos zur\u00fcck. #MarvelPower :D"
    },
    {
        "Id": "post10",
        "Date": "2023-01-10T00:00:00",
        "Description": "The Dark Knight setzt die Geschichte von Bruce Wayne fort, der als maskierter Vigilant Batman f\u00fcr Gerechtigkeit in Gotham City k\u00e4mpft. Der Film konzentriert sich auf Batmans Konfrontation mit dem Joker, einem kriminellen Genie, das die Stadt mit einer Welle des Chaos und der Gewalt \u00fcberzieht. Der Joker, dessen Motive und Vergangenheit r\u00e4tselhaft bleiben, stellt Batman vor moralische Dilemmata und fordert seine Vorstellung von Gerechtigkeit heraus. Neben Batman und dem Joker spielen auch andere wichtige Charaktere eine Rolle, darunter Harvey Dent, Gothams ehrgeiziger Bezirksstaatsanwalt, und Commissioner Gordon. Der Film ist eine komplexe Erz\u00e4hlung \u00fcber Korruption, Heldentum und die d\u00fcnnen Grenzen zwischen Gut und B\u00f6se. The Dark Knight \u00fcberzeugt durch seine realistische Darstellung einer Superheldengeschichte, seine tiefgr\u00fcndige Charakterentwicklung und seine philosophischen \u00dcberlegungen. Die actionreichen Szenen, gepaart mit einer d\u00fcsteren Erz\u00e4hlweise, machen den Film zu einem spannenden und nachdenklichen Erlebnis. The Dark Knight hat das Superheldengenre revolutioniert und gilt als einer der besten Filme seiner Art.",
        "Review": "The Dark Knight, unter der Regie von Christopher Nolan, ist ein Meilenstein in der Welt der Superheldenfilme und weit dar\u00fcber hinaus. Der Film besticht durch seine d\u00fcstere, realistische Darstellung von Gotham City und eine tiefgr\u00fcndige, komplexe Handlung, die das Konzept eines Comicbuchfilms neu definiert. Christian Bale liefert als Bruce Wayne/Batman eine starke Leistung, doch es ist Heath Ledgers Darstellung des Jokers, die als eine der beeindruckendsten schauspielerischen Leistungen in die Filmgeschichte eingeht. Ledger verk\u00f6rpert den Joker als anarchischen, psychopathischen Schurken, dessen Charisma und Unberechenbarkeit den Film dominieren. Die Handlung, die sich um den Kampf zwischen Batman und dem Joker dreht, erforscht Themen wie Moral, Chaos und die Natur des B\u00f6sen. Nolans Regie ist pr\u00e4zise und fesselnd, mit einer perfekten Balance zwischen actionreichen Szenen und emotionalen Momenten. Die visuellen Effekte und die Kameraarbeit sind erstklassig und tragen zur d\u00fcsteren Atmosph\u00e4re des Films bei. Der Soundtrack von Hans Zimmer und James Newton Howard erg\u00e4nzt die gespannte und d\u00fcstere Stimmung des Films. The Dark Knight ist nicht nur ein herausragender Superheldenfilm, sondern auch ein tiefgr\u00fcndiges, psychologisches Drama, das die Grenzen des Genres erweitert und ein bleibendes Erbe in der Filmwelt hinterl\u00e4sst.",
        "Comments": [],
        "RelatedMotionPicture": {
            "Title": "The Dark Knight",
            "type": "Film",
            "Country": "United States",
            "Director": "Christopher Nolan",
            "Actors": [
                "Christian Bale",
                "Heath Ledger",
                "Aaron Eckhart"
            ],
            "Rating": 9.0,
            "Image": "https://wallpapercave.com/wp/wp383267.jpg",
            "Genres": [
                "Action",
                "Crime",
                "Drama"
            ],
            "InitialRelease": 2008,
            "RunTime": 152,
            "AgeRating": 16,
            "Budget": 185000000
        },
        "User": {
            "Name": "Luis",
            "Email": "Luis@example.com",
            "Password": "L^T\"|DN(x}"
        },
        "Comment": "The Dark Knight ist ein Meisterwerk! :O Ledger als Joker ist legend\u00e4r. :D Nolans Vision von Gotham und Batman ist d\u00fcster und packend. Ein Superheldenfilm, der neue Ma\u00dfst\u00e4be setzt! :)"
    }
]en.json…]()

Bevor man die Daten einspielen kann, müssen die Datenbank und das Backend im Hintergrund laufen.

In Postman auf der linken Seite auf `Import` drücken und die Collection zum importieren auswählen

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/ebfc2d4b-8bad-4b43-8204-46939a08a807)

Danach ganz unten rechts auf den `Runner` gehen

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/2de6f2c2-18d3-4a68-826c-e70baeb871f5)

Die `FrameFiesta` Collection in das `Run order` Feld ziehen

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/90c1bdcb-6481-49fc-9342-da76fa8d4192)

Schließlich nur noch rechts bei `Select File` die `DummyData.json` auswählen und auf `Run FrameFiesta` drücken um die Dummydaten einzuspielen

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/9720a6d0-d5f8-401c-866e-1d516440abc6)
