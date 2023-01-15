
from logging import debug
from flask import Flask, request, json
import requests

def setupwebhook():
    setup_data = {  }
    url_setup = 'https://540b-91-90-187-214.eu.ngrok.io';
    requests.post(url_setup, json=setup_data)

app = Flask(__name__)

@app.route('/getnotification', methods=['POST'])
def getnotification(data):
    print(data)

if __name__ == '__main':
    #setupwebhook()
    app.run(debug=True)

