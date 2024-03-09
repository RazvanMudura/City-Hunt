const UserModel = require("../models/UserModel")


const loginUser = async (request, response) => {
    const email = request.body.email
    const password = request.body.password

    try {
        const user = await UserModel.findByCredentials(email, password)
        const token = await user.generateAuthToken()

        return response.json({ user, token })
    }
    catch(error) {
        return response.status(400).json(error)
    }
}


const registerUser = async (request, response) => {
    const user = new UserModel(request.body)

    try {
        const token = await user.generateAuthToken()
        await user.save()

        return response.status(201).json({ user, token })
    }
    catch(error) {
        return response.status(400).json(error)
    }
}



const logoutUser = async (request, response) => {

    try {
        request.user.tokens = request.user.tokens.filter(token => token.token !== request.token)
        await request.user.save()
    }
    catch(error) {
        return response.status(400).json(error)
    }

    return response.send()
}





const getUser = (request, response) => {
    return response.send(request.user)
}


const getUserByUsername = async (request, response) => {
    const username = request.params.username

    try {
        const user = await UserModel.findOne({ username })

        if (!user) 
            return response.send(404).json({ message: "Not Found!" })

        return response.json(user)
    }
    catch(error) {
        return response.status(400).json(error)
    }
}


const addUserArtifact = async (request, response) => {

}

const addUserAcheivement = async (request, response) => {
    
}




module.exports = {
    loginUser,
    logoutUser,
    registerUser,
    getUser,
    getUserByUsername
}