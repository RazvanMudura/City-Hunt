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


const addArtifact = async (request, response) => {
    const id = request.body.id

    try {
        for (let i = 0; i < request.user.artifacts.length; i++) {
            if (request.user.artifacts[i].id === id) 
                return response.status(400).json({ error: "ID already exists!" })
        }



        request.user.artifacts = [...request.user.artifacts, { id }]
        await request.user.save()

        return response.json(request.user)
    }
    catch(error) {
        console.log(error)
        return response.status(400).json(error)
    }
}


const addAchievement = async (request, response) => {
    const id = request.body.id
    

    try {
        for (let i = 0; i < request.user.achievements.length; i++) {
            if (request.user.achievements[i].id === id) 
                return response.status(400).json({ error: "ID already exists!" })
        }

        request.user.achievements = [...request.user.achievements, { id }]
        await request.user.save()

        return response.json(request.user)
    }
    catch(error) {
        return response.status(400).json(error)
    }
}




module.exports = {
    loginUser,
    logoutUser,
    registerUser,
    getUser,
    getUserByUsername,
    addArtifact,
    addAchievement
}