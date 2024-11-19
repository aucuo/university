package com.example.pms2;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Color;
import android.graphics.Typeface;
import android.os.Bundle;
import android.text.SpannableStringBuilder;
import android.text.Spanned;
import android.text.style.ForegroundColorSpan;
import android.text.style.RelativeSizeSpan;
import android.text.style.StyleSpan;
import android.view.GestureDetector;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TabHost;
import android.widget.TextView;
import android.widget.Toast;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private ListView listViewTickets;
    private ListView listViewCart;
    private ArrayAdapter<Ticket> ticketAdapter;
    private ArrayAdapter<Ticket> cartAdapter;
    private List<Ticket> allTickets;
    private EditText editTextFrom;
    private EditText editTextTo;
    private TextView textViewTotalPrice;
    String userLogin;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);

        listViewTickets = findViewById(R.id.listViewTickets);
        listViewCart = findViewById(R.id.listViewСart);
        editTextFrom = findViewById(R.id.editTextFrom);
        editTextTo = findViewById(R.id.editTextTo);
        textViewTotalPrice = findViewById(R.id.textViewTotalPrice);

        userLogin = getIntent().getStringExtra("userLogin");
        setTitle("Glad to see you, " + userLogin + "!");

        TabHost tabHost = (TabHost) findViewById(R.id.tabHost);
        tabHost.setup();
        TabHost.TabSpec tabSpec = tabHost.newTabSpec("tag1");
        //      ----------ВКЛАДКИ------------------------------------------------------------------------------------------------------------------
        tabSpec = tabHost.newTabSpec("tag1");
        tabSpec.setContent(R.id.tab1);
        tabSpec.setIndicator("Tickets");
        tabHost.addTab(tabSpec);

        tabSpec = tabHost.newTabSpec("tag2");
        tabSpec.setContent(R.id.tab2);
        tabSpec.setIndicator("Shop Cart");
        tabHost.addTab(tabSpec);

        tabHost.setCurrentTab(0);

        ticketsLoad();

        cartAdapter = new ArrayAdapter<Ticket>(this, android.R.layout.simple_list_item_1) {
            @Override
            public View getView(int position, View convertView, ViewGroup parent) {
                if (convertView == null) {
                    convertView = LayoutInflater.from(getContext()).inflate(android.R.layout.simple_list_item_1, parent, false);
                }

                TextView textView = convertView.findViewById(android.R.id.text1);
                Ticket ticket = getItem(position);
                String ticketInfo = "Ticket № " + ticket.getId() + "\n" +
                        "Direction: " + ticket.getDirectionFrom() + " - " + ticket.getDirectionTo() + "\n" +
                        "Price: " + ticket.getPrice() + " BYN";

                SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(ticketInfo);

                ForegroundColorSpan grayColorSpan = new ForegroundColorSpan(Color.GRAY);
                RelativeSizeSpan smallSizeSpan = new RelativeSizeSpan(0.8f);
                spannableStringBuilder.setSpan(grayColorSpan, 0, 6, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
                spannableStringBuilder.setSpan(smallSizeSpan, 0, 6, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

                ForegroundColorSpan purpleColorSpan = new ForegroundColorSpan(Color.parseColor("#ff33ff"));
                spannableStringBuilder.setSpan(purpleColorSpan, ticketInfo.indexOf("Direction:"), ticketInfo.indexOf("Direction:") + 10, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

                ForegroundColorSpan goldColorSpan = new ForegroundColorSpan(Color.parseColor("#FFD700"));
                RelativeSizeSpan largeSizeSpan = new RelativeSizeSpan(1.2f);
                StyleSpan boldStyleSpan = new StyleSpan(Typeface.BOLD);
                spannableStringBuilder.setSpan(goldColorSpan, ticketInfo.indexOf("Price:"), ticketInfo.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
                spannableStringBuilder.setSpan(largeSizeSpan, ticketInfo.indexOf("Price:"), ticketInfo.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
                spannableStringBuilder.setSpan(boldStyleSpan, ticketInfo.indexOf("Price:"), ticketInfo.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

                textView.setText(spannableStringBuilder);

                return convertView;
            }
        };
        listViewCart.setAdapter(cartAdapter);

        listViewTickets.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
                try {
                    Ticket selectedTicket = (Ticket) parent.getItemAtPosition(position);

                    ArrayAdapter<Ticket> cartAdapter = (ArrayAdapter<Ticket>) listViewCart.getAdapter();
                    cartAdapter.add(selectedTicket);
                    updateTotalPrice();
                    cartAdapter.notifyDataSetChanged();

                    return true;
                } catch (Exception e) {
                    e.printStackTrace();
                    Toast.makeText(MainActivity.this, "Ex: " + e.getMessage(), Toast.LENGTH_SHORT).show();
                    return false;
                }
            }
        });
    }

    private void ticketsLoad() {
        try {
            DatabaseHelper dbHelper = new DatabaseHelper(this);
            allTickets = dbHelper.getAllTickets();

            ticketAdapter = new ArrayAdapter<Ticket>(this, android.R.layout.simple_list_item_1, allTickets) {
                @Override
                public View getView(int position, View convertView, ViewGroup parent) {
                    if (convertView == null) {
                        convertView = LayoutInflater.from(getContext()).inflate(android.R.layout.simple_list_item_1, parent, false);
                    }

                    TextView textView = convertView.findViewById(android.R.id.text1);
                    Ticket ticket = getItem(position);
                    String ticketInfo = "Ticket № " + ticket.getId() + "\n" +
                            "Direction: " + ticket.getDirectionFrom() + " - " + ticket.getDirectionTo() + "\n" +
                            "Price: " + ticket.getPrice() + " BYN";

                    SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(ticketInfo);

                    ForegroundColorSpan grayColorSpan = new ForegroundColorSpan(Color.GRAY);
                    RelativeSizeSpan smallSizeSpan = new RelativeSizeSpan(0.8f);
                    spannableStringBuilder.setSpan(grayColorSpan, 0, 6, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
                    spannableStringBuilder.setSpan(smallSizeSpan, 0, 6, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

                    ForegroundColorSpan purpleColorSpan = new ForegroundColorSpan(Color.parseColor("#ff33ff"));
                    spannableStringBuilder.setSpan(purpleColorSpan, ticketInfo.indexOf("Direction:"), ticketInfo.indexOf("Direction:") + 10, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

                    ForegroundColorSpan goldColorSpan = new ForegroundColorSpan(Color.parseColor("#FFD700"));
                    RelativeSizeSpan largeSizeSpan = new RelativeSizeSpan(1.2f);
                    StyleSpan boldStyleSpan = new StyleSpan(Typeface.BOLD);
                    spannableStringBuilder.setSpan(goldColorSpan, ticketInfo.indexOf("Price:"), ticketInfo.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
                    spannableStringBuilder.setSpan(largeSizeSpan, ticketInfo.indexOf("Price:"), ticketInfo.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
                    spannableStringBuilder.setSpan(boldStyleSpan, ticketInfo.indexOf("Price:"), ticketInfo.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

                    textView.setText(spannableStringBuilder);

                    return convertView;
                }
            };

            listViewTickets.setAdapter(ticketAdapter);
        } catch (Exception e) {
            Toast.makeText(this, "Ex: " + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }
    }

    public void filterTickets(View view) {
        String from = editTextFrom.getText().toString().trim();
        String to = editTextTo.getText().toString().trim();

        if (from.isEmpty() && to.isEmpty()) {
            ticketsLoad();
        } else {
            List<Ticket> filteredTickets = new ArrayList<>();

            for (Ticket ticket : allTickets) {
                boolean matchFrom = from.isEmpty() || ticket.getDirectionFrom().equalsIgnoreCase(from);
                boolean matchTo = to.isEmpty() || ticket.getDirectionTo().equalsIgnoreCase(to);

                if (matchFrom && matchTo) {
                    filteredTickets.add(ticket);
                }
            }

            ticketAdapter.clear();
            ticketAdapter.addAll(filteredTickets);
            ticketAdapter.notifyDataSetChanged();
        }
    }
    public void clearFilters(View view) {
        editTextFrom.getText().clear();
        editTextTo.getText().clear();
        ticketsLoad();
    }

    public void clearCart(View view) {
        cartAdapter.clear();
        updateTotalPrice();
    }
    private void updateTotalPrice() {
        try {
            double totalPrice = 0;
            for (int i = 0; i < cartAdapter.getCount(); i++) {
                Ticket ticket = cartAdapter.getItem(i);
                totalPrice += ticket.getPrice();
            }

            if (totalPrice == 0) {
                textViewTotalPrice.setText("There is no tickets yet!");
            } else {
                DecimalFormat decimalFormat = new DecimalFormat("#0.00"); // Форматирование до двух знаков после запятой
                String formattedPrice = decimalFormat.format(totalPrice);
                textViewTotalPrice.setText("Total Price: " + formattedPrice + " BYN");
            }
        } catch (Exception e) {
            Toast.makeText(this, "Ex: " + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }
    }
    public void buyCart(View view) {
        if(textViewTotalPrice.getText() != "There is no tickets yet!")
        {
            Toast.makeText(MainActivity.this, textViewTotalPrice.getText() + " were withdrawn from the card!", Toast.LENGTH_LONG).show();
            clearCart(view);
            DatabaseHelper dbHelper = new DatabaseHelper(this);
            dbHelper.deleteUser(userLogin);

            redirectToSignIn();
            Toast.makeText(MainActivity.this, "Also your account was deleted :3 byyeeeeeee", Toast.LENGTH_LONG).show();
        }
    }
    public void redirectToSignIn() {
        Intent intent = new Intent(this, SignInActivity.class);
        startActivity(intent);
    }
}