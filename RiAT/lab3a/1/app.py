from flask import Flask, jsonify, request

app = Flask(__name__)

# In-memory representation of notes
notes = [
    {'id': 1, 'title': 'Example Note', 'content': 'Content of the example note'}
]

# Create a new note
@app.route('/notes', methods=['POST'])
def create_note():
    note_data = request.json
    note_id = len(notes) + 1
    note_data['id'] = note_id
    notes.append(note_data)
    return jsonify(note_data), 201

# Get all notes
@app.route('/notes', methods=['GET'])
def get_notes():
    return jsonify(notes)

# Get a single note by ID
@app.route('/notes/<int:note_id>', methods=['GET'])
def get_note(note_id):
    note = next((note for note in notes if note['id'] == note_id), None)
    if note is None:
        return jsonify({'message': 'Note not found'}), 404
    return jsonify(note)

# Update a note
@app.route('/notes/<int:note_id>', methods=['PUT'])
def update_note(note_id):
    note = next((note for note in notes if note['id'] == note_id), None)
    if note is None:
        return jsonify({'message': 'Note not found'}), 404
    note_data = request.json
    note.update(note_data)
    return jsonify(note)

# Delete a note
@app.route('/notes/<int:note_id>', methods=['DELETE'])
def delete_note(note_id):
    global notes
    notes = [note for note in notes if note['id'] != note_id]
    return jsonify({'message': 'Note deleted'}), 200

# This code is for demonstration and won't run in this environment.
# You can run it in a local Python environment with Flask installed.
# Use 'flask run' command in the terminal to start the server.
