import { ApolloServer, gql } from "apollo-server-express";
import express from "express";
import mongoose from "mongoose";
import dotenv from "dotenv";
import colors from "colors";
import { typeDefs } from "./typeDefs";
import { resolvers } from "./resolvers";
import { connectDB } from "./db";

const startServer = async () => {
  const { app, server } = await configure();

  app.listen({ port: process.env.PORT }, () =>
    console.log(
      `Server ready at http://localhost:${process.env.PORT}${server.graphqlPath}`
        .magenta.underline.bold
    )
  );
};

//Configuring all variables
const configure = async () => {
  // CONFIGURE DOTENV, WHICH FILE TO USE
  dotenv.config();
  let app;
  let server;
  await connectDB();
  app = express();
  server = new ApolloServer({
    typeDefs,
    resolvers,
  });
  server.applyMiddleware({ app });
  return { app, server };
};

//Starting the backend
startServer();
