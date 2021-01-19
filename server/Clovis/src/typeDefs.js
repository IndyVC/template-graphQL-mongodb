import { gql } from "apollo-server-express";

export const typeDefs = gql`
  type Query {
    hello: String!
  }
  type Mutation {
    createCat(name: String!): Cat
  }
  type Cat {
    id: ID!
    name: String!
  }
`;
