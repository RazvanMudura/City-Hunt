const jwt = require("jsonwebtoken")
const UserModel = require("../models/UserModel")


const auth = async (request, response, next) => {
    try {
        const token = request.header("Authorization").replace("Bearer ", "")

        if (!token)
            return response.send({ user: null })

        const decoded = jwt.verify(token, process.env.JWT_SECRET)
        const user = await UserModel.findOne({ _id: decoded._id, "tokens.token": token })


        if (!user)
            throw new Error("Invalid token!")


        request.user = user
        request.token = token
        next()
    }
    catch (error) {
        return response.status(401).send({ error: "Not Authenticated" })
    }
}

module.exports = auth