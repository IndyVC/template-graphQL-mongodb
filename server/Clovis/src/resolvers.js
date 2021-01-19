import { Cat } from "./models/Cat";

export const resolvers = {
  Query: {
    hello: () => "Hello!",
    cats: () => Cat.find(),
  },
  Mutation: {
    //par1 = parent
    //par2 = arguments passed to the function. Destructuring it to get the exact properties.
    createCat: async (_, { name }) => {
      const kitty = new Cat({ name });
      await kitty.save();
      return kitty;
    },
  },
};
