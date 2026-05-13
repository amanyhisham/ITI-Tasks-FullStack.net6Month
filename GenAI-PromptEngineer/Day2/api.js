const express = require('express');
const { quickSort } = require('./script');

const app = express();
const PORT = process.env.PORT || 3000;

app.use(express.json());

app.post('/sort', (req, res) => {
    try {
        const { array } = req.body;
        if (!Array.isArray(array)) {
            return res.status(400).json({ error: 'Input must be an array of numbers.' });
        }
        const sorted = quickSort(array);
        res.json({ sorted });
    } catch (error) {
        res.status(400).json({ error: error.message });
    }
});

app.listen(PORT, () => {
    console.log(`Server running on port ${PORT}`);
});