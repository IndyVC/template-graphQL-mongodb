import { Cat } from "./models/Cat";

export const resolvers = {
  Query: {
    hello: () => "Hello!",
  },
  Mutation: {
    //par1 = parent
    //par2 = arguments passed to the function. Destructuring it to get the exact properties.
    createCat: (_, { name }) => {
      const kitty = new Cat({ name });
      return kitty.save();
    },
  },
};
