const { MongoClient, ObjectID } = require("mongodb");
const Express = require("express");
const BodyParser = require('body-parser');

const server = Express();

server.use(BodyParser.json());
server.use(BodyParser.urlencoded({ extended: true }));

const client = new MongoClient("mongodb+srv://admin:oM7Hl5HdSNYmUMzH@racinggame.mhaytik.mongodb.net/?retryWrites=true&w=majority&appName=RacingGame")

var collection;

server.listen("3000", async () => {
    try {
        await client.connect();
        collection = client.db("RacingGame").collection("Users");
        console.log("Listening at :3000...");
    } catch (e) {
        console.error(e);
    }
});

server.get("/Users", async (request, response, next) => 
{
    try {
        let result = await collection.find({}).toArray();
        response.send(result);
    } catch (e) {
        response.status(500).send({ message: e.message });
    }
});

server.post("/Users", async (request, response, next) => 
{
    try {
        let result = await collection.insertOne(request.body);
        response.send(result);
    } catch (e) {
        response.status(500).send({ message: e.message });
    }
});

server.get("/Users/:playerID", async (request, response, next) => 
{
    try {
        let result = await collection.findOne({ "playerID": request.params.playerID });
        response.send(result);
    } catch (e) {
        response.status(500).send({ message: e.message });
    }
});

server.put("/Users/:playerID", async (request, response, next) => 
{
    try {
        let result = await collection.updateOne(
            { "playerID": request.params.playerID },
            { "$set": request.body }
        );
        response.send(result);
    } catch (e) {
        response.status(500).send({ message: e.message });
    }
});

